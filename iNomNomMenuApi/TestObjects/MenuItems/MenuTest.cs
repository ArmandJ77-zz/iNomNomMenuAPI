using System;
using System.Collections.Generic;
using System.Text;

namespace TestObjects.MenuItems
{
    public class MenuTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public List<MenuItemTest> Items { get; set; }
    }
}
