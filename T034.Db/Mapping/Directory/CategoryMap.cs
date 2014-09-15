using Db.Entity.Directory;
using FluentNHibernate.Mapping;

namespace Db.Mapping.Directory
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id).Column("CategoryId").GeneratedBy.Increment();

            Map(p => p.Name);
        }
    }
}
