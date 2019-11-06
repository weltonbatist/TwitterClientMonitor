using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClientMonitor.Common.Model
{
    public class CapturedObject
    {
        public virtual Campaign Campaign { get; set; }
        public virtual DateTime DateOfCapture { get; set; }
        public virtual string Json { get; set; }
    }
}
