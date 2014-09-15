using Db.Entity.Directory;
using FluentNHibernate.Mapping;

namespace Db.Mapping.Directory
{
    public class MaterialTypeMap : ClassMap<MaterialType>
    {
        public MaterialTypeMap()
        {
            Id(x => x.Id).Column("MaterialTypeId").GeneratedBy.Increment();

            Map(p => p.Name);
        }
    }
}
