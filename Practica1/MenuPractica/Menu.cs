using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPractica
{
    internal class Menu
    {
        public List<MenuItem> Items;
        public Menu()
        {
            Items = new List<MenuItem>()
            {
                new AddNewItem("Добавление нового элемента"),
                new DeleteItemFromList("Удаление элемента")
            };
        }


        public void ShowMenu()
        {
            if (Items.Count > 0)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Items[i].description}");
                }
            }
        }
    }
}
