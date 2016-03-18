namespace SimpleArchitecture.Domain.Utils
{
    public interface IJsonUtil
    {
        string Serialize<T>(T target);  
    }
}