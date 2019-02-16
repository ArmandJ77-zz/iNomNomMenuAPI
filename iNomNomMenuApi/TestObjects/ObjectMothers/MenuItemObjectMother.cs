using System;
using System.Collections.Generic;
using System.Text;
using TestObjects.MenuItems;

namespace TestObjects.ObjectMothers
{
    /// <summary>
    /// Not going to implement full object mother/builder pattern here due to time constraints
    /// </summary>
    public class MenuItemObjectMother
    {
        public MenuItemTest CreateMenuItem => new MenuItemTest
        {
            MenuId = 1,
            IsDeleted = false,
            Name = "Test menu item 1",
            Description = "Some test description",
            Price = 999,
            TimeToPrep = 888,
        };

        public MenuItemTest EditMenuItem => new MenuItemTest
        {
            MenuId = 1,
            IsDeleted = false,
            Name = "Edited Menu Item",
            Description = "Edited description",
            Price = 5,
            TimeToPrep = 9,
        };

        public static List<MenuItemTest> GetList(int count, int menuId)
        {
            var list = new List<MenuItemTest>();

            for (var i = 0; i < count; i++)
            {
                list.Add(new MenuItemTest
                {
                    MenuId = menuId,
                    IsDeleted = false,
                    Name = $"Test menu item {i}",
                    Description = $"Some test description for menu item {i}",
                    Price = i *4,
                    TimeToPrep = i*2,
                });
            }

            return list;
        }
    }
}
