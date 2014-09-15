using Db.Entity.Directory;
using FluentNHibernate.Mapping;

namespace Db.Mapping.Directory
{
    public class TechnologyMap : ClassMap<Technology>
    {
        public TechnologyMap()
        {
            Id(x => x.Id).Column("TechnologyId").GeneratedBy.Increment();

            Map(p => p.Name);
        }
    }
}
