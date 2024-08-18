namespace Benja.Service
{
    public interface IHtmlService
    {
        byte[] Write<T>(IList<T> registers);
    }
}
