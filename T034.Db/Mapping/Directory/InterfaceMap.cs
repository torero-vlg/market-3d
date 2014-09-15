using Db.Entity.Directory;
using FluentNHibernate.Mapping;

namespace Db.Mapping.Directory
{
    public class InterfaceMap : ClassMap<Interface>
    {
        public InterfaceMap()
        {
            Id(x => x.Id).Column("InterfaceId").GeneratedBy.Increment();

            Map(p => p.Name);
        }
    }
}
