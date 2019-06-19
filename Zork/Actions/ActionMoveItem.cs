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
            Inventory foundPartnerItem = new Inventory();
            Inventory originatorInventory = new Inventory();
             

            bool hasFoundItem = false;
            bool hasFoundPartnerItem = false;


            try
            {
                Take();
                //Switch(MovementType)
                //Case take
                //Take()
                

                //Case Put
                //Put()

                //Case Drop
                //Drop()

            }
                    
            catch (Exception ex)
            {
                Debug.Error(ex.ToString());
            }

        }

        private void Take()
        {
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

            if (hasFoundItem && !hasFoundPartnerItem)
            {
                toInventory.AddItem(foundItem);
                fromInventory.Items.Remove(foundItem);
                Console.WriteLine("You picked up a " + foundItem.Name);
            }

        }

            private void Put()
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
                                    foreach (Item item in toInventory.Items) //Search location inventory
                                    {

                                        if (item.Name.ToLower() == inputArray[i].ToLower())
                                        {
                                            if (item is Inventory)
                                            {
                                                originatorInventory = toInventory;
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
        private void Drop()
        {
            

        }
    }
}
