using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnitTest.Model;
using Xunit;
using Xunit.Abstractions;

namespace TestDemo
{
    public class StudentTest: ApiControllerTestBase
    {
        public HttpClient Client { get; }
        public ITestOutputHelper Output { get; }


        public StudentTest(ITestOutputHelper outputHelper)
        {
            // var server = new TestServer(WebHost.CreateDefaultBuilder()
            //.UseStartup<Startup>());
            // Client = server.CreateClient();

            // 从父类里面获取HttpClient对象
            Client = base.GetClient();
            Output = outputHelper;
        }

        [Fact]
        public async Task Get_ShouldBe_Ok()
        {
            // 2、Act
            var response = await Client.GetAsync($"api/student");

            // Output
            string context = await response.Content.ReadAsStringAsync();
            Output.WriteLine(context);
            List<Student> list = JsonConvert.DeserializeObject<List<Student>>(context);

            // Assert
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public async Task Post_ShouldBe_Ok()
        {
            // 1、Arrange
            Student entity = new Student()
            {
             Name="测试9",
             Age=25,
             Gender="男"
            };

            var str = JsonConvert.SerializeObject(entity);
            HttpContent content = new StringContent(str);

            // 2、Act
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await Client.PostAsync("api/student", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            Output.WriteLine(responseBody);

            // 3、Assert
            Assert.Equal("true", responseBody);
        }
    }
}
