using System.Collections.Generic;
using System.Web.Mvc;
using Db.Entity;
using Db.Entity.Directory;

namespace T034.ViewModel
{
    public class PrinterViewModel : Printer
    {
        public IEnumerable<SelectListItem> PurposeList { get; set; }
        public IEnumerable<SelectListItem> TechnologyList { get; set; }

        public Printer ToModel()
        {
            return new Printer
                {
                    Id = Id,
                    Area = Area,
                    Category = new Category { Id = 1},
                    Count = Count,
                    Name = Name,
                    Article = Article,
                    Description = Description,
                    Diametr = Diametr,
                    HasDisplay = HasDisplay,
                    Price = Price,
                    Printhead =  Printhead,
                    Purpose = new Purpose { Id = Purpose.Id },
                    Technology = new Technology { Id = Technology.Id },
                    Weight = Weight
                };
        }
    }
}