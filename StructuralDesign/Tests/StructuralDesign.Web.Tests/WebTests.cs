namespace StructuralDesign.Web.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Testing;

    using Xunit;

    public class WebTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> server;

        public WebTests(WebApplicationFactory<Startup> server)
        {
            this.server = server;
        }

        [Fact(Skip = "Example test. Disabled for CI.")]
        public async Task IndexPageShouldReturnStatusCode200WithTitle()
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("<title>", responseContent);
        }

        [Fact(Skip = "Example test. Disabled for CI.")]
        public async Task AccountManagePageRequiresAuthorization()
        {
            var client = this.server.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
            var response = await client.GetAsync("Identity/Account/Manage");
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }

        [Fact]
        public async Task HomePageShouldOpenSuccessfully()
        {
            HttpClient client = this.server.CreateClient();

            var responese = await client.GetAsync("/");
            responese.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task HomePageShouldContains()
        {
            HttpClient client = this.server.CreateClient();

            var responese = await client.GetAsync("/");
            var html = await responese.Content.ReadAsStringAsync();
            string expectedString = "<h1 class=" + "display - 4" + ">Welcome to StructuralDesign</h1>";

            Assert.Contains(expectedString, html);
        }
    }
}
