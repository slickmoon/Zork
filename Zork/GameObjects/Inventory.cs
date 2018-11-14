using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Inventory : Item
    {
        public List<Item> Items;

        public Inventory(string name, string description) : base(name,name,description)
        {
        
        }

        public Inventory(List<Item> items, string name, string description) : base (name,name,description)
        {
            this.Items = items;
        }

        public void SortItems(bool stop = false)
        {
            bool doIStopYet = false;

            //blah blah blah check if its sorted yet
            doIStopYet = true;
            if (!doIStopYet)
            {

                SortItems(false);
            }

        }
    }
}
