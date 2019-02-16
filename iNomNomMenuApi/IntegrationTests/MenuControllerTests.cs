using Domain.Menu.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestObjects.ControllerEndpoints;
using TestObjects.Infrastructure;

namespace IntegrationTests
{
    [TestFixture]
    public class MenuControllerTests : BaseIntegrationTest
    {
        [Test]
        public async Task Menu_GetList_ListOfMenus()
        {
            var queryResult = await Client.GetAsync(MenuControllerEndpoints.Get);
            queryResult.EnsureSuccessStatusCode();

            var result = await queryResult.Content.Deserialize<List<MenuDto>>();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.GreaterThan(0));
        }
    }
}
