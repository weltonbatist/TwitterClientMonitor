using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClientMonitor.Common.Model
{
    public class FilterTweet
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Text { get; set; }
        public virtual string Sepator { get; set; }
        public virtual bool Active { get; set; }
    }
}
