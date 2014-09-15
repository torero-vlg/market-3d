using System.Collections.Generic;
using Db.Entity.Directory;

namespace Db.Entity
{
    public class Printer : Product
    {
        /// <summary>
        /// Количество печатающих головок
        /// </summary>
        public virtual int Printhead { get; set; }
        
        /// <summary>
        /// Назначение
        /// </summary>
        public virtual Purpose Purpose { get; set; }
        
        /// <summary>
        /// Диаметр нити
        /// </summary>
        public virtual double Diametr { get; set; }
        
        /// <summary>
        /// Технология
        /// </summary>
        public virtual Technology Technology { get; set; }
        
        /// <summary>
        /// Область печати
        /// </summary>
        public virtual string Area { get; set; }

        /// <summary>
        /// Наличие экрана
        /// </summary>
        public virtual bool HasDisplay { get; set; }

        /// <summary>
        /// Масса
        /// </summary>
        public virtual double Weight { get; set; }

        /// <summary>
        /// Типы материалов
        /// </summary>
        public virtual IList<MaterialType> MaterialTypes { get; set; }

        /// <summary>
        /// Интерфейсы
        /// </summary>
        public virtual IList<Interface> Interfaces { get; set; }
    }
}
