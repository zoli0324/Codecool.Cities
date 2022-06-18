using Codecool.CitiesEf.Api.Model;
using Newtonsoft.Json;

namespace Codecool.CitiesEF.Test
{
    public class CitiesControllerTests
    {
        private readonly HttpClient _client;
        public CitiesControllerTests()
        {
            TestingWebAppFactory<Program> factory = new TestingWebAppFactory<Program>();
            _client = factory.CreateClient();

        }
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task TestGetAllCity()
        {
            //Act
            var response = await _client.GetAsync("api/Cities");

            //Assert
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<List<CityViewModel>>(responseString);
            Assert.IsTrue(actual.Count > 0);
        }
    }
}