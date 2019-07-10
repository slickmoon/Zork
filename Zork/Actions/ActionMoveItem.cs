using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class ActionMoveItem : ActionBase
    {
        string[] inputArray;
        private Player player;
        private ItemMovements direction;

        public ActionMoveItem(string[] inputArray, Player player, ItemMovements direction) //Add the inventory that the item is coming from
        {
            this.inputArray = inputArray;

            this.player = player;

            this.direction = direction;
        }

        public override void Do()
        {
            base.Do();

            try
            {
                switch(direction)
                {
                    case ItemMovements.Take:
                        Take();
                        break;
                    case ItemMovements.Put:
                        Put();
                        break;
                    case ItemMovements.Drop:
                        Drop();
                        break;
                    default:
                        break;

                }
            }

            catch (Exception ex)
            {
                Debug.Error(ex.ToString());
            }

        }

        private void Take()
        {
            string inventoryName;
            Inventory invent = null;
            string itemName;
            Item item = null;

            if(inputArray.Length > 3)     //are we taking from an inventory item? 
            {
                inventoryName = inputArray[3];
                //take sword from bag
                invent = SearchForInventory(inventoryName);
            }  

            if(inputArray.Length > 1)
            {
                itemName = inputArray[1];
                if (invent == null)
	            {
                    item = SearchInventoryForItem(player.CurrentLoc.Inventory, itemName);
	            }else 
                {
                    item = SearchInventoryForItem(invent, itemName);
                }

                if (item != null)
                {
                    player.Inventory.AddItem(item);

                    if (invent == null)
	                {
                        player.CurrentLoc.Inventory.Items.Remove(item);
                        Console.WriteLine("You picked up a " + item.Name);
                    }
                    else 
                    {
                        invent.Items.Remove(item);
                        Console.WriteLine("You picked up a " + item.Name + " from " + invent.Name);
                    }
                    
                }else 
                {
                    Console.WriteLine("I can't find a " + itemName);
                }
            } 

        }

        void Put()
        {
            //put sword in bag
            //bag can be in location or player
            //sword can be in location or player
            string inventoryName;
            Inventory invent = null;
            string itemName;
            Item item = null;

            if(inputArray.Length > 3)   //figure out if we are taking from a bag first
            {
                inventoryName = inputArray[3];
                //put sword in bag
                invent = SearchForInventory(inventoryName); //find inventory to put item into

                itemName = inputArray[1];

                if (invent != null)
	            {
                    //Found an inventory to put into, now lets find the item
                    Inventory itemInventory;

                    item = SearchInventoryForItem(player.CurrentLoc.Inventory, itemName);
                    if(item != null)
                    {
                        itemInventory = player.CurrentLoc.Inventory;
                    }
                    else
                    {

                        item = SearchInventoryForItem(player.Inventory, itemName);
                        if(item != null)
                            itemInventory = player.Inventory;
                        else
                            return;
                    }


                    if (item != null)
                    {
                        
                        invent.AddItem(item);
                        itemInventory.Items.Remove(item);
                        Console.WriteLine("You put the " + item.Name + " in " + invent.Name);
                    }
                    else
                    {
                        Console.WriteLine("I couldn't find a " + itemName);
                        return;
                    }


	            }
                else 
                {
                    Console.WriteLine("I can't put a " + itemName + " in a " + inventoryName);
                    return;
                }
            }
            else
            {
                Console.WriteLine("Put what where?");
                return;
            }
        }

        void Drop()
        {
            string inventoryName;
            Inventory invent = null;
            string itemName;
            Item item = null;

            if (inputArray.Length > 3)
            {
                inventoryName = inputArray[3];
                //drop sword from bag
                invent = SearchForInventory(inventoryName, false);
            }

            if (inputArray.Length > 1)
            {
                itemName = inputArray[1];
                if (invent == null)
                {
                    item = SearchInventoryForItem(player.Inventory, itemName, false);
                }
                else
                {
                    item = SearchInventoryForItem(invent, itemName, false);
                }

                if (item != null)
                {
                    player.CurrentLoc.Inventory.AddItem(item);

                    if (invent == null)
                    {
                        player.Inventory.Items.Remove(item);
                        Console.WriteLine("You dropped " + item.Name);
                    }
                    else
                    {
                        invent.Items.Remove(item);
                        Console.WriteLine("You dropped " + item.Name + " from " + invent.Name);
                    }

                }
                else
                {
                    Console.WriteLine("I can't find a " + itemName);
                }

            }
        }

        Item SearchInventoryForItem(Inventory inventory, string searchString, bool recursive = true, int callNumber = 0 ) 
        {
            Item itemout = null;
            if (callNumber > 100)
                return null;

            foreach (Item i in inventory.Items)
            {
                if (i.Name.ToLower() == searchString.ToLower())
                {
                    return i;
                }
                
                if (i.isInventory && recursive) //go recursive
                {
                    Inventory invent = i as Inventory;
                    itemout = SearchInventoryForItem(invent, searchString, recursive, callNumber++);
                }
                if (itemout != null)
                {
                    return itemout;
                }
                
            }
            return null;
        }

        Inventory SearchForInventory(string inventoryName, bool searchLoc = true)
        {
            Inventory invent = null;
            //take sword from bag
            if (!String.IsNullOrEmpty(inventoryName))
            {
                invent = SearchInventoryForItem(player.Inventory, inventoryName) as Inventory; //search player

                if (invent == null)
                {
                    if(searchLoc)
                    {
                         invent = SearchInventoryForItem(player.CurrentLoc.Inventory, inventoryName) as Inventory; //search location
                    }
                   
                }
            }
            else
            {
                Console.WriteLine("I can't do that.");
            }
            return invent;
        }
    }
}