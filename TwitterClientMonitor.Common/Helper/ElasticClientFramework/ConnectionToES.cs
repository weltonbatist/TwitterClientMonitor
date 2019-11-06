using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;

namespace TwitterClientMonitor.Common.Helper.ElasticClientFramework
{
    public class ConnectionToES
    {
        #region Connection string to connect with Elasticsearch
        public List<string> Uris { get; set; }

        public ConnectionToES(List<string> uris)
        {
            this.Uris = uris;
        }

        public ElasticClient EsClient()
        {
            ConnectionSettings connectionSettings;
            ElasticClient elasticClient;
            SingleNodeConnectionPool connectionPool;

         
            var totalitens = Uris.Count;
            var nodes = new Uri[totalitens];

            for (int i = 0; i < Uris.Count; i++)
            {
                if (!string.IsNullOrEmpty(Uris[i]))
                {
                    nodes[i] = new Uri(Uris[i]);
                }
            }

            connectionPool = new SingleNodeConnectionPool(nodes[0]);
            connectionSettings = new ConnectionSettings(connectionPool);
            elasticClient = new ElasticClient(connectionSettings);

            return elasticClient;
        }

        #endregion Connection string to connect with Elasticsearch
    }
}
