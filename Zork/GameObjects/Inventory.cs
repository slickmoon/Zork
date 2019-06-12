using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
  public class Inventory : Item
    {
        public List<Item> Items = new List<Item>();


        public Inventory(string name, string description) : base(name, name, description)
        {
            
        }

        public Inventory() : base("", "", "")  
        {
            CanBePickedUp = false;
        }

        public Inventory(List<Item> items, string name, string description) : base(name, name, description)
        {
            this.Items = items;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void DestroyItem(Item item)
        {
            foreach (Item i in Items)
            {
                if (i == item)
                {
                    Items.Remove(i);
                    break;
                }
            }
        }

        public void DestroyItem(string itemName) 
        {
            Items.Remove(FindItemByName(itemName));
        }

        public Item GetItem(string itemName)
        {
            Item i;
            i = FindItemByName(itemName);

            if(i != null) 
            {
                return i;
            }
            else
            {
                    return null;
            }
        }

        private Item FindItemByName(string itemName)
        {
            foreach (Item i in Items)
            {
                if (i.Name.ToLower() == itemName.ToLower())
                {
                    return i;
                }
            }
            Console.WriteLine("Item: " + itemName + " not found!");
            return null;
        }

        public Item RemoveItem(string itemName)
        {
            Item removeditem = null;
            removeditem = FindItemByName(itemName);
            if(removeditem != null) {
                    Items.Remove(removeditem);
            }else
            {
                Console.WriteLine("Item " + itemName + " not found");
            }

            return removeditem;
        }

        public string ToString()
        {
            string output = "";
            //If there are any items in Items, then show "The following items are here: "
            Inventory fakeInvent = new Inventory();
            Inventory i;

            if(Items.Count != 0)       
            { 
                output += "\nInventory: \n---------------------- ";
                foreach (Item item in Items) //TODO, move this foreach to a function call, and allow this function to call itself when it finds an item that is a inventory, and pass in that inventory to the function call
	            {
                    output +=  "\n" + item.Name;
                    if(item.GetType().Equals(fakeInvent))
                    {
                        i = item;
                        output += "--->"; //note as the start of the inventory
                        foreach(Item inventoryitem in i)
                        {
                            output += "\n" + item.Name;
                        }
                        output += "<---"; //note as the end of the inventory
                    }
	            }
            } else 
            {
                
            }
                    output += "\n";
            return output;
        }
        
        /*public void UseItem(Item item) 
        {
            item.Use();
        }
        */

        /*
        public void SortItems(bool stop = false)
        {
            bool doIStopYet = false;

            //blah blah blah check if its sorted yet
            //doIStopYet = true;
            if (!doIStopYet)
            {

                SortItems(false);
            }

        }
        */
    }
}
