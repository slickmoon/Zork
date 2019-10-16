using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
  public class ActionUse : ActionBase
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
            Item foundItem = new Item();

            try
            {

                foreach (Item item in currentInventory.Items)
                {
                    for (int i = 0; i < inputArray.Length; i++)
                    {
                        if (item.Name.ToLower() == inputArray[i].ToLower())
                        {
                            foundItem = item;
                        }
                    }
                }

                if (foundItem != null)
                {
                    if(inputArray.Length < 3)
                    {
                        Console.WriteLine("Used " + foundItem.Name);
                        foundItem.Use();
                        if (foundItem.SingleUse == true)
                            currentInventory.DestroyItem(foundItem);

                    } else if (inputArray.Length > 3 && inputArray.Length < 5) //Use key on door
                    {
                        GateBase foundGate;
                        foreach(GateBase g in currentPlayer.currentLoc.Gates)
                        {
                            if (g.Name.ToLower() == inputArray[3].ToLower())
                            {
                                foundGate = g;
                                if (foundGate != null)
                                {
                                    foundGate.Do(foundItem);
                                    if (foundItem.SingleUse == true)
                                        currentInventory.DestroyItem(foundItem);
                                }
                                else
                                {
                                    Console.WriteLine("I couldn't find what to use that on");
                                }
                                break;
                            }
                        }
                        
                        
                    }
                    else{
                        Console.WriteLine("I don't know what to use that on");    
                    }

                    
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
