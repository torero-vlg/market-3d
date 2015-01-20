using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class GoodsMap : ClassMap<Goods>
    {
        public GoodsMap()
        {
            Id(x => x.Id).Column("GoodsId").GeneratedBy.Increment();

            Map(p => p.Name);
        }
    }
}
