﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Inventory : Item
    {
        public List<Item> Items;

        public Inventory(string name, string description) : base(name, name, description)
        {
            
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
                if (i.name.ToLower() == itemName.ToLower())
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
