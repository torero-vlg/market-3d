using Db.Entity.Directory;
using FluentNHibernate.Mapping;

namespace Db.Mapping.Directory
{
    public class PurposeMap : ClassMap<Purpose>
    {
        public PurposeMap()
        {
            Id(x => x.Id).Column("PurposeId").GeneratedBy.Increment();

            Map(p => p.Name);
        }
    }
}
