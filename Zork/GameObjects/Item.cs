using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
  public class Item : GameObject
    {
        public bool SingleUse = false;
        public bool CanBePickedUp = true;

        public bool isInventory = false;

        public Item(string name, string shortname, string description) : base(name, shortname, description)
        {

        }

        public Item() : base("Blank", "BlankItem", "BlankItem")
        { 
            
        }   

        public void Use()
        {
            Console.WriteLine("You used " + Name + ".");
        }
    }
}
