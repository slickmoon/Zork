﻿using System;
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
                if (!String.IsNullOrEmpty(inventoryName))
                {
                    invent = SearchInventory(player.Inventory, inventoryName) as Inventory; //search player

                    if(invent == null)
                    {
                        invent = SearchInventory(player.CurrentLoc.Inventory, inventoryName) as Inventory; //search location
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
            }


            if(inputArray.Length > 1)
            {
                itemName = inputArray[1];
                if (invent == null)
	            {
                    item = SearchInventory(player.CurrentLoc.Inventory, itemName);
	            }else 
                {
                    item = SearchInventory(invent, itemName);
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
            /*
                        if (hasFoundItem && !hasFoundPartnerItem)  
                        {
                            if (inputArray.Length > 3 && !hasFoundPartnerItem)
                            {
                                foreach (Item item in fromInventory.Items) //Search first inventory
                                {

                                    if (item.Name.ToLower() == inputArray[i].ToLower())
                                    {
                                        if (item is Inventory)
                                        {
                                            originatorInventory = fromInventory;
                                            foundPartnerItem = item as Inventory;

                                            hasFoundPartnerItem = true;
                                            break;
                                        }
                                        else if (!item.CanBePickedUp)
                                        {
                                            Console.WriteLine(inputArray[i] + " cannot be picked up");
                                        }
                                    }
                                }

                                if(!hasFoundPartnerItem)
                                {
                                    //Search other inventory
                                    foreach (Item item in inventory.Items) //Search location inventory
                                    {

                                        if (item.Name.ToLower() == inputArray[i].ToLower())
                                        {
                                            if (item is Inventory)
                                            {
                                                originatorInventory = inventory;
                                                foundPartnerItem = item as Inventory;

                                                hasFoundPartnerItem = true;
                                                break;
                                            }
                                            else if (!item.CanBePickedUp)
                                            {
                                                Console.WriteLine(inputArray[i] + " cannot be picked up");
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            break;
                        }

                        // Take item and put it in player inventory
                        */
            /*
                        else if (hasFoundItem && hasFoundPartnerItem)
            {
                foundPartnerItem.AddItem(foundItem);
                originatorInventory.Items.Remove(foundItem);
                Console.WriteLine("You picked up a " + foundItem.Name);
            }
            */
        }
        void Drop()
        {
            

        }

        Item SearchInventory(Inventory inventory, string searchString, int callNumber = 0) 
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
                
                if (i.isInventory) //go recursive
                {
                    Inventory invent = i as Inventory;
                    itemout = SearchInventory(invent, searchString, callNumber++);
                }
                if (itemout != null)
                {
                    return itemout;
                }
                
            }
            return null;
        }
    }
}