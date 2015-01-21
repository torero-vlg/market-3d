using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class GoodsDetailMap : ClassMap<GoodsDetail>
    {
        public GoodsDetailMap()
        {
            Id(x => x.Id).Column("GoodsDetailId").GeneratedBy.Increment();

            Map(p => p.Name);

            References(p => p.Goods).Column("GoodsId")
                .Not.LazyLoad();
        }
    }
}
