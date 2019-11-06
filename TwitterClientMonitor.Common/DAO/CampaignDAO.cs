using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClientMonitor.Common.Model;

namespace TwitterClientMonitor.Common.DAO
{
    public class CampaignDAO
    {
        ISession session;

        public CampaignDAO(ISession session)
        {
            this.session = session;
        }

        public void Add(Campaign obj)
        {

            ITransaction tx = session.BeginTransaction();

            try
            {
                session.Save(obj);
                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();

                throw ex;
            }
        }

        public IList<Campaign> List()
        {
            var result = session.QueryOver<Campaign>().List();

            return result;
        }
    }
}
