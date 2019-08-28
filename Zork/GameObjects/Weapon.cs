using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Weapon : Item
    {

        //Item stats
        public int Damage = 5;

        public Weapon(string name, string shortname, string description) : base(name, shortname, description)
        {

        }

        public Weapon() : base("Blank", "BlankItem", "BlankItem")
        {

        }

        public virtual void Use(GameObject source, GameObject target)
        {
            NPC t;
            t = target as NPC;
            if (t != null)
            {
                Console.WriteLine("You attcked with the " + this.Name + " at the " + t.Name);
            }



        }
    }
}
