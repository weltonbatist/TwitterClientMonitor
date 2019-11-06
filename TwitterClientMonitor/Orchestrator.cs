using System;
using System.Collections.Generic;
using TwitterClientMonitor.Client;
using TwitterClientMonitor.Common.DAO;
using TwitterClientMonitor.Common.Helper;
using TwitterClientMonitor.Common.Model;

namespace TwitterClientMonitor
{
    internal class Orchestrator
    {
        string AppName;

        public Orchestrator(string AppName)
        {
            this.AppName = AppName;

            if (string.IsNullOrEmpty(this.AppName))
            {
                throw new ArgumentNullException($"AppName Is Null");
            }
        }

        internal void Magic()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                ConfigurationDAO configurationDAO = new ConfigurationDAO(session);
                CampaignDAO campaignDAO = new CampaignDAO(session);

                var result = configurationDAO.GetByName(this.AppName);
                var listcamp = campaignDAO.List();

                if (result is null)
                {
                    throw new Exception($"AppName:{this.AppName} Not Found!");
                }
                else if (listcamp is null)
                {
                    throw new Exception($"Campaign Not Found!");
                }
                else
                {
                    InstanceConsumer(result, listcamp);
                }
                
            }
        }

        private void InstanceConsumer(Configuration result, IList<Campaign> camp)
        {
            Consumer consumer = new Consumer(result, camp);
        }
    }
}