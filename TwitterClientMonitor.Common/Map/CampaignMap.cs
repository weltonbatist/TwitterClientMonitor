using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClientMonitor.Common.Model;

namespace TwitterClientMonitor.Common.Map
{
    public class CampaignMap: ClassMap<Campaign>
    {
        public CampaignMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.StartDate).Not.Nullable();
            Map(x => x.StopDate).Not.Nullable();
            Map(x => x.Active).Not.Nullable();
            References(x => x.FilterTweet, "IdFilterTweets");
        }
    }
}
