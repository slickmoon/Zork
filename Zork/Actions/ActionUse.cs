using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class ActionUse : ActionBase
    {
        string[] inputArray;
        Player currentPlayer;
        Inventory currentInventory;

        public ActionUse(string[] inputArray, Player currentPlayer)
        {
            this.inputArray = inputArray;

            this.currentPlayer = currentPlayer;

            this.currentInventory = currentPlayer.Inventory;
        }

        public override void Do()
        {
            base.Do();
            Item foundItem;

            try
            {

                foreach(Item item in currentInventory)
                {
                    for (int i = 0; i < inputArray.Length; i++)
                    {
                        if(item.Name.toLower() == inputArray[i].toLower())
                        {
                            foundItem = item;
                        }
                    }
                }

                if (foundItem)
                {
                    Console.WriteLine("Used " + foundItem.Name)
                    foundItem.Use();
                }
                else
                {
                    Console.WriteLine("You don't have that item to use");
                }
            }
            catch (Exception ex)
            {
                Debug.Log("Fix Your Game Epic!" + "\n" + ex.ToString());
            }
        }
    }
}
