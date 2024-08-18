namespace Benja.Service
{
    public interface IJsonService
    {
        byte[] Write<T>(IList<T> registers);
    }
}
