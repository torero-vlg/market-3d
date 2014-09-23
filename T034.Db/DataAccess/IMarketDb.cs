using Db.Entity;

namespace Db.DataAccess
{
    /// <summary>
    /// Базовый интерфейс по работе с сообщениями
    /// </summary>
    public interface IMarketDb : IBaseDb
    {
        /// <summary>
        /// Добавить 3D объект
        /// </summary>
        /// <param name="subject">3D объект</param>
        /// <returns></returns>
        int AddSubject(Subject subject);
    }
}
