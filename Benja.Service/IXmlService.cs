namespace Benja.Service
{
    public interface IXmlService
    {
        byte[] Write<T>(IList<T> registers);
    }
}
