using Db.Entity.Directory;

namespace Db.Entity
{
    public class Material : Product
    {
        /// <summary>
        /// Диаметр нити
        /// </summary>
        public virtual double Diametr { get; set; }

        /// <summary>
        /// Масса
        /// </summary>
        public virtual double Weight { get; set; }

        /// <summary>
        /// Тип материала
        /// </summary>
        public virtual MaterialType MaterialType { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        public virtual string Color { get; set; }
    }
}
