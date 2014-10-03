using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class PrinterMap : SubclassMap<Printer>
    {
        public PrinterMap()
        {
            KeyColumn("PrinterId");

            Map(p => p.Area);
            Map(p => p.Diametr);
            Map(p => p.HasDisplay);
            Map(p => p.Printhead);
            Map(p => p.Weight);

            References(p => p.Purpose).Column("PurposeId")
                .Not.LazyLoad();
            References(p => p.Technology).Column("TechnologyId")
                .Not.LazyLoad();

            HasManyToMany(x => x.MaterialTypes)
                .Table("PrinterMaterialType")
                .ParentKeyColumn("PrinterId")
                .ChildKeyColumn("MaterialTypeId");

            HasManyToMany(x => x.Interfaces)
                .Table("PrinterInterface")
                .ParentKeyColumn("PrinterId")
                .ChildKeyColumn("InterfaceId");

            //HasOne<Product>(x => x.Id);
        }
    }
}
