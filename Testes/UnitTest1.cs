using System;
using Xunit;

namespace Testes
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            //Arrange 


            var application = new WebApplicationFactory<Startup>()
        .WithWebHostBuilder(builder =>
        {
            // ... Configure test services
        });

            var client = application.CreateClient();

            //Act  
            //Assert
        }
    }
}
