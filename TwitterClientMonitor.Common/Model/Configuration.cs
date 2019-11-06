using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClientMonitor.Common.Model
{
    public class Configuration
    {
        public virtual int Id { get; set; }
        public virtual string NameApp { get; set; }
        public virtual string AppKey { get; set; }
        public virtual string Secret { get; set; }
    }
}
