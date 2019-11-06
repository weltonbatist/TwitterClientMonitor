using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClientMonitor.Common.Model
{
    public class Campaign
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime StopDate { get; set; }
        public virtual bool Active { get; set; }
        public virtual FilterTweet FilterTweet { get; set; }

        public virtual bool Between()
        {
            return StartDate <= DateTime.Now && StopDate >= DateTime.Now;
        }
    }
}
