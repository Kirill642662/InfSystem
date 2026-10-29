using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPractica
{
    internal class AddNewItem: MenuItem
    {
        public AddNewItem(string text)
        {
            description = text;
        }
        public override void Select(List<MenuItem> list)
        {
            MenuItem item = new MenuItem();
            Console.WriteLine("Введите описание элемента, который хотите добавить");
            item.description = Console.ReadLine();
            list.Add(item);
            Console.WriteLine("Элемент успешно добавлен!");
        }
    }
}
