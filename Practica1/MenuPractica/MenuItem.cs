using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPractica
{
    internal class MenuItem
    {
        public string description {  get; set; }
        public virtual void Select(List<MenuItem> list)
        {
        }

    }
}
