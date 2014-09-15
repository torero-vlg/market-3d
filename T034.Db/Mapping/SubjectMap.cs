using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class SubjectMap : ClassMap<Subject>
    {
        public SubjectMap()
        {
            Id(x => x.Id).Column("SubjectId").GeneratedBy.Assigned();

            Map(p => p.Article);
            Map(p => p.Description);
            Map(p => p.IsAvailable);
            Map(p => p.Name);
            Map(p => p.Price);

            References(p => p.Category).Column("CategoryId")
                .Not.LazyLoad(); 
        }
    }
}
