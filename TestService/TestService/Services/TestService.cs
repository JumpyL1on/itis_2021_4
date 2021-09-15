using System.Collections.Generic;
using Newtonsoft.Json;
using TestService.Dto;

namespace TestService.Services
{
    public class TestService : ITestService
    {
        public string GetTestJson(int toAdd)
        {
            return GetTestJson(toAdd.ToString());
        }
        
        public string GetTestJson(string toAdd)
        {
            var strings = JsonConvert.DeserializeObject<List<string>>(StaticDTO.TestJson);
            for (var i = 0; i < 3; i++) 
                strings?.Add(toAdd);
            return JsonConvert.SerializeObject(strings);
        }

        public string GetPMstring(string argument)
        {
            return $"Have a nice day, {argument}!";
        }
    }
}