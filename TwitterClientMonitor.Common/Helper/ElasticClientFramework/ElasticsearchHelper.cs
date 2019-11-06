using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClientMonitor.Common.Helper.ElasticClientFramework
{
    public sealed class ElasticsearchHelper
    {
        private static ElasticsearchHelper Instance;

        public static ConnectionToES _ConnectionToES { get; set; }

        private static List<string> _Uris;

        private ElasticsearchHelper()
        {

        }

        public static ElasticsearchHelper GetInstance()
        {
            if (Instance is null)
            {
                _ConnectionToES = new ConnectionToES(_Uris);
                return new ElasticsearchHelper();

            }

            return Instance;
        }

        public void LoadUris(List<string> Uris)
        {
            if (Instance is null)
            {
                throw new Exception("Para utilizar esse método é obrigatorio ter utilizado o método GetInstance()");
            }
            else if (Uris is null)
            {
                throw new ArgumentException("Parametro Uris não pode ser nulo", "Uris");
            }
            else if (Uris.Count <= 0)
            {
                throw new ArgumentException("Parametro Uris deve conter pelo menos um elemento", "Uris");
            }
            else
            {
                _Uris = Uris;
                _ConnectionToES = new ConnectionToES(_Uris);
            }
        }



    }
}
