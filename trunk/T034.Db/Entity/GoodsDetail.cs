namespace Db.Entity
{
    /// <summary>
    /// Атрибут товара
    /// </summary>
    public class GoodsDetail : Entity
    {
        /// <summary>
        /// Название
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Товар
        /// </summary>
        public virtual Goods Goods { get; set; }
    }
}
