using System.Reflection;

namespace Benja.Service
{
    public interface IExcelService
    {
        Task<byte[]> Write<T>(IList<T> registers);
    }
}
