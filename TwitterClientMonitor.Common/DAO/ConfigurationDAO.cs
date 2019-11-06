using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClientMonitor.Common.Model;

namespace TwitterClientMonitor.Common.DAO
{
    public class ConfigurationDAO
    {
        ISession session;

        public ConfigurationDAO(ISession session)
        {
            this.session = session;
        }

        public void Add(Configuration obj)
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

        public IList<Configuration> List()
        {
            return session.QueryOver<Configuration>().List();
        }

        public Configuration GetByName(string name)
        {
            return session.QueryOver<Configuration>().Where(x => x.NameApp == name).List().FirstOrDefault();
        }
    }
}
