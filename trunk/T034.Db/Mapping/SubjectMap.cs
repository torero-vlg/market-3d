using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class SubjectMap : ClassMap<Subject>
    {
        public SubjectMap()
        {
            Id(x => x.Id).Column("SubjectId").GeneratedBy.Assigned();

            HasOne<Product>(x => x.Id);
        }
    }
}
