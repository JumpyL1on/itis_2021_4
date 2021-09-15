using NUnit.Framework;
using TestService.Services;

namespace TestService.Test.Unit
{
    public class Tests
    {
        private ITestService TestService { get; set; }
        [SetUp]
        public void Setup()
        {
            TestService = new Services.TestService();
        }

        [Test]
        public void TestService_GetTestJson()
        {
            var added = 5;
            var result = TestService.GetTestJson(added.ToString());
            Assert.AreEqual($"[\"str1\",\"str2\",\"{added}\",\"{added}\",\"{added}\"]", result);
        }
        
        [Test]
        public void TestService_GetPMstring()
        {    
            string append = null;
            var result = TestService.GetPMstring(append);
            Assert.AreEqual($"Have a nice day, {append}!", result);
        }
    }
}