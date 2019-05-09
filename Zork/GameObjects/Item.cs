using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Item : GameObject
    {
        private bool singleUse = false;

        public Item(string name, string shortname, string description) : base(name, shortname, description)
        {

        }

        public void Use()
        {
            Console.WriteLine("You used an " + name + ".")
        }
    }
}
