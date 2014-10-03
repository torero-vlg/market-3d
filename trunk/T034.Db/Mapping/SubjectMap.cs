using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class SubjectMap : SubclassMap<Subject>
    {
        public SubjectMap()
        {
            KeyColumn("SubjectId");

            //HasOne<Product>(x => x.Id);
        }
    }
}
