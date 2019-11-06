using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClientMonitor.Model.Create
{
    class Entities
    {
        public List<object> hashtags { get; set; }
        public List<object> urls { get; set; }
        public List<object> user_mentions { get; set; }
        public List<object> symbols { get; set; }
    }
}
