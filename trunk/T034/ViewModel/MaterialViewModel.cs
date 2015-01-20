using System.Collections.Generic;
using System.Web.Mvc;
using Db.Entity;
using Db.Entity.Directory;

namespace T034.ViewModel
{
    public class MaterialViewModel : Material
    {
        public IEnumerable<SelectListItem> MaterialTypeList { get; set; }

        public Material ToModel()
        {
            return new Material
            {
                Id = Id,
                Category = new Category { Id = 1 },
                Count = Count,
                Name = Name,
                Article = Article,
                Description = Description,
                Diametr = Diametr,
                Color = Color,
                Price = Price,
                MaterialType = new MaterialType { Id = MaterialType.Id },
                Weight = Weight
            };
        }
    }
}