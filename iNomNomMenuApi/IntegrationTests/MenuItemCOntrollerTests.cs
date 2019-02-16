using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Repositories.Models;
using TestObjects.ControllerEndpoints;
using TestObjects.Infrastructure;

namespace IntegrationTests
{
    [TestFixture]
    public class MenuItemControllerTests: BaseIntegrationTest
    {
        [Test]
        public async Task MenuItem_Get_ListOfItems()
        {
            var queryResult = await Client.GetAsync(MenuItemControllerEndpoints.GetList(5,1));
            queryResult.EnsureSuccessStatusCode();

            var result = await queryResult.Content.Deserialize<List<MenuItem>>();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task MenuItem_Get_AMenuItem()
        {
            var queryResult = await Client.GetAsync(MenuItemControllerEndpoints.Get(1));
            queryResult.EnsureSuccessStatusCode();

            var result = await queryResult.Content.Deserialize<MenuItem>();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task MenuItem_Create_ReturnCreatedId()
        {
            var response = await Client.PostAsJsonAsync(MenuItemControllerEndpoints.Create, MenuItemObjectMother.CreateMenuItem);
            var result = await response.Content.Deserialize<long>();

            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public async Task MenuItem_Update_UpdatedId()
        {


            var response = await Client.PutAsJsonAsync(MenuItemControllerEndpoints.Update, MenuItemObjectMother.EditMenuItem);
            var result = await response.Content.Deserialize<long>();

            Assert.That(result, Is.GreaterThan(0));

            var queryResult = await Client.GetAsync(MenuItemControllerEndpoints.Get(1));
            queryResult.EnsureSuccessStatusCode();

            var editedResult = await queryResult.Content.Deserialize<MenuItem>();

            StringAssert.AreEqualIgnoringCase(MenuItemObjectMother.EditMenuItem.Name,editedResult.Name);
            StringAssert.AreEqualIgnoringCase(MenuItemObjectMother.EditMenuItem.Description, editedResult.Description);
            Assert.That(editedResult.Price, Is.EqualTo(MenuItemObjectMother.EditMenuItem.Price));
            Assert.That(editedResult.TimeToPrep, Is.EqualTo(MenuItemObjectMother.EditMenuItem.TimeToPrep));
        }

        [Test]
        public async Task MenuItem_Delete_IdOfDeletedRecord()
        {
            var entityToDeleteId = 2;
            var response = await Client.DeleteAsync(MenuItemControllerEndpoints.Delete(entityToDeleteId));
            var result = await response.Content.Deserialize<long>();

            Assert.That(result, Is.EqualTo(entityToDeleteId));

            try
            {
                var queryResult = await Client.GetAsync(MenuItemControllerEndpoints.Get(1));
            }
            catch (Exception e)
            {
                if(e.InnerException.ToString() == "Entity Not Found")
                    Assert.True(true);
                
                Assert.True(false);
            }
        }
    }
}
