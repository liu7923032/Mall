using System.Threading.Tasks;
using Mall.Web.Controllers;
using Shouldly;
using Xunit;

namespace Mall.Web.Tests.Controllers
{
    public class HomeController_Tests: MallWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
