using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimpleArchitecture.Domain.Utils;

namespace SimpleArchitecture.Util
{
    public class JsonUtil : IJsonUtil
    {
        public string Serialize<T>(T target)
        {
            var setting = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(target, setting);
        }
    }
}