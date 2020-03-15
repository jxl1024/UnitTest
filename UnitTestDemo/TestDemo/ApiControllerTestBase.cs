using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using UnitTestDemo;

namespace TestDemo
{
    public class ApiControllerTestBase
    {
        protected HttpClient GetClient()
        {
            var builder = new WebHostBuilder()
                                // 指定使用当前目录
                                .UseContentRoot(Directory.GetCurrentDirectory())
                                // 使用Startup类作为启动类
                                .UseStartup<Startup>()
                                // 设置使用测试环境
                                .UseEnvironment("Testing");
            var server = new TestServer(builder);
            // 创建HttpClient
            HttpClient client = server.CreateClient();

            return client;
        }
    }
}
