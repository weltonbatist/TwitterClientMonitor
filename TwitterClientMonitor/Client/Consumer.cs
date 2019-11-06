using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitterClientMonitor.Common.Helper.ElasticClientFramework;
using TwitterClientMonitor.Common.Model;
using TwitterClientMonitor.Motor;
using TwitterClientMonitor.Util;

namespace TwitterClientMonitor.Client
{
    public class Consumer
    {
        public Service service;
       

        public Consumer(Configuration configuration, IList<Campaign> campaigns)
        {
            service = new Service(configuration, campaigns);
            service.Start(CallbackTweet);
            SycloLifeObjectInfinity();
           
        }

        private void SycloLifeObjectInfinity()
        {
            while (true)
            {
                Thread.Sleep(10 * 1000);
            }
        }

        public string CallbackTweet(string param)
        {
            Console.WriteLine($"{DateTime.Now} Consumer - Info: {param}");

            var obj = HelpSerialize<Rootobject>.DeserializeObject(param);

            CreateDocInElasticsearch(obj);

            return param;
        }

        private void CreateDocInElasticsearch(Rootobject rootobject)
        {
            List<string> list = new List<string>();
            list.Add("http://localhost:9200/");

            var myJson = new
            {
                DataSistema = DateTime.Now,
                DataCriacao = rootobject.created_at,
                Texto = rootobject.text,
                TotalAmigos = rootobject.user.friends_count,
                TotalSeguidores = rootobject.user.followers_count,
                Fonte = rootobject.source,
                NomeUsuario = rootobject.user.name,
                LocalizacaoHabilitada = rootobject.user.geo_enabled,
                Localizacao = rootobject.user.location
            };

            var conn = new ConnectionToES(list);

            var response = conn.EsClient().Index(myJson, x =>
                x.Index("TwitterClientMonitor")
                .Type("character")
                .Id(new Guid().ToString()).Refresh(Elasticsearch.Net.Refresh.True));

            if (response.IsValid)
            {
                Console.WriteLine($"{DateTime.Now} - Insert ES OK");
            }
            else
            {
                Console.WriteLine($"{DateTime.Now} - Insert ES Error");
            }

        }
    }
}
