using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClientMonitor.Common.Model;

namespace TwitterClientMonitor.Common.Map
{
    public class FilterTweetMap: ClassMap<FilterTweet>
    {
        public FilterTweetMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Sepator).Not.Nullable();
            Map(x => x.Text).Not.Nullable();
            Map(x => x.Active).Not.Nullable();
        }
    }
}
