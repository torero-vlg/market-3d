using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class MaterialMap : SubclassMap<Material>
    {
        public MaterialMap()
        {
            KeyColumn("MaterialId");

            Map(p => p.Color);
            Map(p => p.Diametr);
            Map(p => p.Weight);

            References(p => p.MaterialType).Column("MaterialTypeId")
                .Not.LazyLoad();

            //HasOne<Product>(x => x.Id);
        }
    }
}
