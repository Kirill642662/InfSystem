using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MenuPractica
{
    internal class DeleteItemFromList: MenuItem
    {
        public DeleteItemFromList(string text) 
        {
            description = text;
        }
        public override void Select(List<MenuItem> list)
        {
            MenuItem item = new MenuItem();
            Console.WriteLine("Выберите порядковый номер элемента, который хотите удалить");
            int indexRemove = int.Parse(Console.ReadLine()) - 1;
            list.RemoveAt(indexRemove);
            Console.WriteLine("Элемент был успешно удален!");
        }
    }
}
