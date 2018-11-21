using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Inventory
    {
        public List<Item> Items;
        public Inventory inv;

        public Inventory()
        {
            SortItems();
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
