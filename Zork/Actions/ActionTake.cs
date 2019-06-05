using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class ActionTake : ActionBase
    {
        string[] inputArray;
        Player currentPlayer;
        Inventory currentInventory;

        public ActionTake(string[] inputArray, Player currentPlayer, Inventory inventoryToTakeFrom) //Add the inventory that the item is coming from
        {
            this.inputArray = inputArray;

            this.currentPlayer = currentPlayer;

            this.currentInventory = inventoryToTakeFrom;
        }

        public override void Do() 
        {
            base.Do();
            Item foundItem = new Item();

            try
            {
                foreach (Item item in currentInventory.Items)
                {
                    for (int i = 0; i < inputArray.Length; i++)
                    {
                        if (item.Name.ToLower() == inputArray[i].ToLower() )
                        {
                            if(item.CanBePickedUp)
                            {
                                foundItem = item;

                                currentPlayer.Inventory.AddItem(item);
                                currentInventory.Items.Remove(item);
                            }
                            else if (!item.CanBePickedUp)
                            {
                                Console.WriteLine(inputArray[i] + " cannot be picked up");
                            }
                        }
                        
                    }
                }
                //If found item, remove from current inventory, and add to player inventory

                //add to inventory and get item on current mapid
            }
            catch (Exception ex)
            {
                Debug.Error(ex.ToString());
            }

        }
    }
}
