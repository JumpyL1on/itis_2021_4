using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Core.Implementations;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace RedisTest
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var configuration = new RedisConfiguration
            {
                ConnectionString = "localhost",
                Database = 2
            };
            var manager = new RedisCacheConnectionPoolManager(configuration);
            var serializer = new NewtonsoftSerializer();
            var client = new RedisCacheClient(manager, serializer, configuration);
            var database = client.GetDbFromConfiguration();
            var testDto = new TestDto
            {
                Value = "testValue",
                IntVal = 1
            };
            await database.AddAsync("testKey", testDto);
            var value = await database.GetAsync<TestDto>("testKey");
            Console.WriteLine(JsonConvert.SerializeObject(value));
            Console.ReadKey();
        }
    }
}