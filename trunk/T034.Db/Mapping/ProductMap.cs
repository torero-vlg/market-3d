using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).Column("ProductId").GeneratedBy.Increment();

            Map(p => p.Article);
            Map(p => p.Description);
            Map(p => p.Count);
            Map(p => p.Name);
            Map(p => p.Price);

            References(p => p.Category).Column("CategoryId")
                .Not.LazyLoad(); 
        }
    }
}
