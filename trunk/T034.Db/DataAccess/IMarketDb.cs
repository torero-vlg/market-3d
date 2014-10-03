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

        /// <summary>
        /// Добавить 3D принтер
        /// </summary>
        /// <param name="printer">3D принтер</param>
        /// <returns></returns>
        int AddPrinter(Printer printer);

        /// <summary>
        /// Удалить принтер
        /// </summary>
        /// <param name="id"></param>
        void DeletePrinter(int id);
    }
}
