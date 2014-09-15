using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class MaterialMap : ClassMap<Material>
    {
        public MaterialMap()
        {
            Id(x => x.Id).Column("MaterialId").GeneratedBy.Assigned();

            Map(p => p.Article);
            Map(p => p.Color);
            Map(p => p.Description);
            Map(p => p.Diametr);
            Map(p => p.IsAvailable);
            Map(p => p.Name);
            Map(p => p.Price);
            Map(p => p.Weight);

            References(p => p.Category).Column("CategoryId")
                .Not.LazyLoad();
            References(p => p.MaterialType).Column("MaterialTypeId")
                .Not.LazyLoad();
        }
    }
}
