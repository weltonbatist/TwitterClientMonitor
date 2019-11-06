using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClientMonitor.Common.Model;

namespace TwitterClientMonitor.Common.DAO
{
    public class FilterTweetDAO
    {
        ISession session;

        public FilterTweetDAO(ISession session)
        {
            this.session = session;
        }

        public void Add(FilterTweet obj)
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

        public IList<FilterTweet> List()
        {
            return session.QueryOver<FilterTweet>().List();
        }
    }
}
