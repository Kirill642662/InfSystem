using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPractica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            while (true)
            {
                menu.ShowMenu();
                int choice = int.Parse(Console.ReadLine());
                menu.Items[choice - 1].Select(menu.Items);
            }
        }
    }
}
