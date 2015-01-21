using System.Collections.Generic;

namespace Db.Entity
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Goods : Entity
    {
        public Goods()
        {
            Details = new List<GoodsDetail>();
        }

        /// <summary>
        /// Название
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Типы материалов
        /// </summary>
        public virtual IList<GoodsDetail> Details { get; set; }
    }
}
