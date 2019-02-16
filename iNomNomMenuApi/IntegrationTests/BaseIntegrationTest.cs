using AutoMapper;
using iNomNomMenuApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using TestObjects.ObjectMothers;

namespace IntegrationTests
{
    public class BaseIntegrationTest
    {
        public MenuContext MenuContext { get; set; }
        public HttpClient Client { get; set; }

        public MenuObjectMother MenuObjectMother { get; set; }
        public MenuItemObjectMother MenuItemObjectMother { get; set; }

        public BaseIntegrationTest()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            Mapper.Reset();
            var server = new TestServer(builder);
            Client = server.CreateClient();
            MenuContext = server.Host.Services.GetService(typeof(MenuContext)) as MenuContext;
            

            MenuItemObjectMother = new MenuItemObjectMother();
            MenuObjectMother = new MenuObjectMother();
        }

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            BuildDb();
        }

        private void BuildDb()
        {
            MenuContext.Menus.Add(new Menu
            {
                Id = 1,
                Name = "Test Menu",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Items = new List<MenuItem>
                {
                    new MenuItem()
                    {
                        IsDeleted = false,
                        Name = "Menu Item 1",
                        Description = "Menu item 1 description",
                        Price = 5,
                        TimeToPrep = 9,
                    },
                    new MenuItem()
                    {
                        IsDeleted = false,
                        Name = "Menu Item 2",
                        Description = "Menu item 2 description",
                        Price = 2,
                        TimeToPrep = 1,
                    },
                    new MenuItem()
                    {
                        IsDeleted = false,
                        Name = "Menu Item 3",
                        Description = "Menu item 3 description",
                        Price = 8,
                        TimeToPrep = 2,
                    },
                }
            });

            MenuContext.SaveChanges();
        }
    }
}
