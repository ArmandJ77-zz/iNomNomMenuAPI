using System;
using TestObjects.MenuItems;

namespace TestObjects.ObjectMothers
{
    public class MenuObjectMother
    {
        public MenuTest aDefaultMenu => new MenuTest
        {
            Id = 1,
            Name = "Test Menu",
            DateCreated = DateTime.Now,
            IsDeleted = false,
            Items = MenuItemObjectMother.GetList(5, 1)
        };
    }
}
