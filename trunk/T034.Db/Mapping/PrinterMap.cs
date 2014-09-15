using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class PrinterMap : ClassMap<Printer>
    {
        public PrinterMap()
        {
            Id(x => x.Id).Column("PrinterId").GeneratedBy.Assigned();

            Map(p => p.Area);
            Map(p => p.Article);
            Map(p => p.Description);
            Map(p => p.Diametr);
            Map(p => p.HasDisplay);
            Map(p => p.IsAvailable);
            Map(p => p.Name);
            Map(p => p.Price);
            Map(p => p.Printhead);
            Map(p => p.Weight);

            References(p => p.Category).Column("CategoryId")
                .Not.LazyLoad(); 
            References(p => p.Purpose).Column("PurposeId")
                .Not.LazyLoad();
            References(p => p.Technology).Column("TechnologyId")
                .Not.LazyLoad();

            HasMany(x => x.MaterialTypes).KeyColumn("PrinterId")
                .Not.LazyLoad()
                .Cascade.Delete();

            HasMany(x => x.Interfaces).KeyColumn("InterfaceId")
                .Not.LazyLoad()
                .Cascade.Delete();
        }
    }
}
