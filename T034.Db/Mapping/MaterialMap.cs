using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class MaterialMap : ClassMap<Material>
    {
        public MaterialMap()
        {
            Id(x => x.Id).Column("MaterialId").GeneratedBy.Assigned();

            Map(p => p.Color);
            Map(p => p.Diametr);
            Map(p => p.Weight);

            References(p => p.MaterialType).Column("MaterialTypeId")
                .Not.LazyLoad();

            HasOne<Product>(x => x.Id);
        }
    }
}
