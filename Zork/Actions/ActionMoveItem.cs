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
            /*
            Item foundItem = new Item();
            Inventory foundPartnerItem = new Inventory();
            Inventory originatorInventory = new Inventory();
             

            bool hasFoundItem = false;
            bool hasFoundPartnerItem = false;
            */

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

                //Take()    //take sword from bag --sword inside bag, and bag is on ground or on player


                //Case Put
                //Put()     //put sword in bag --sword on player or ground, bag on ground or on player

                //Case Drop //drop sword from bag --sword on player, bag on player
                //Drop()

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

            if(inputArray.Length > 3)
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

            /*
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (!hasFoundItem)
                {
                    foreach (Item item in fromInventory.Items)
                    {

                        if (item.Name.ToLower() == inputArray[i].ToLower())
                        {
                            if (item.CanBePickedUp)
                            {
                                foundItem = item;

                                hasFoundItem = true;
                                break;
                            }
                            else if (!item.CanBePickedUp)
                            {
                                Console.WriteLine(inputArray[i] + " cannot be picked up");
                            }
                        }

                    }
                }
                */

        }

        void Put()
        {
            //put sword in bag
            //bag can be in location or player
            //sword can be in location or player

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
                    
                    if (invent == null)
                    {
                        Console.WriteLine("I can't find a " + inventoryName + " to take from");
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