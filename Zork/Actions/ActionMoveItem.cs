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
        private Inventory toInventory;
        private Inventory fromInventory;
        private string movementDirection;

        public ActionMoveItem(string[] inputArray, Inventory toInventory, Inventory fromInventory, string direction) //Add the inventory that the item is coming from
        {
            this.inputArray = inputArray;

            this.toInventory = toInventory;

            this.fromInventory = fromInventory;

            this.movementDirection = direction;
        }

        public override void Do()
        {
            base.Do();
            Item foundItem = new Item();

            bool hasFoundItem = false;

            try
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (hasFoundItem)
                        break;
                    
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
                    if (hasFoundItem)
                    {
                        toInventory.AddItem(foundItem);
                        fromInventory.Items.Remove(foundItem);
                        Console.WriteLine("You picked up a " + foundItem.Name);
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
