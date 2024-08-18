namespace Benja.Service
{
    public interface IYamlService
    {
        byte[] Write<T>(IList<T> registers);
    }
}
