using Db.Entity.Directory;

namespace Db.Entity
{
    public class Product : Entity
    {
        /// <summary>
        /// Название
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// Артикул
        /// </summary>
        public virtual string Article { get; set; }
        
        /// <summary>
        /// Категория
        /// </summary>
        public virtual Category Category { get; set; }
        
        /// <summary>
        /// Цена
        /// </summary>
        public virtual double Price { get; set; }
        
        /// <summary>
        /// Полное описание товара
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Количество в наличии
        /// </summary>
        public virtual int Count { get; set; }
    }
}
