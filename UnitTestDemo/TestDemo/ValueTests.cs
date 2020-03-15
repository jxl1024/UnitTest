using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnitTestDemo;
using Xunit;
using Xunit.Abstractions;

namespace TestDemo
{
    public class ValueTests
    {
        public HttpClient _client { get; }
        public ITestOutputHelper Output { get; }

        /// <summary>
        /// 构造方法
        /// </summary>
        public ValueTests(ITestOutputHelper outputHelper)
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
           .UseStartup<Startup>());
            _client = server.CreateClient();
            Output = outputHelper;
        }

        [Fact]
        public async Task GetById_ShouldBe_Ok()
        {
            // 1、Arrange
            var id = 1;

            // 2、Act
            // 调用异步的Get方法
            var response = await _client.GetAsync($"/api/value/{id}");

            // 3、Assert
            // 模拟测试失败
            //Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            // 输出返回信息
            // Output
            var responseText = await response.Content.ReadAsStringAsync();
            Output.WriteLine(responseText);

            // 3、Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
