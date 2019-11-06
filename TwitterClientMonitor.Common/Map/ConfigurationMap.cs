using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClientMonitor.Common.Model;

namespace TwitterClientMonitor.Common.Map
{
    public class ConfigurationMap: ClassMap<Configuration>
    {
        public ConfigurationMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.NameApp).Unique();
            Map(x => x.AppKey).Not.Nullable();
            Map(x => x.Secret).Not.Nullable();
            
        }
    }
}
