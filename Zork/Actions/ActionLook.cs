using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
  public class ActionLook : ActionBase
    {
        string[] inputArray;
        Player currentPlayer;

        public ActionLook(string[] inputArray, Player currentPlayer)
        {
            this.inputArray = inputArray;

            this.currentPlayer = currentPlayer;
        }

        public override void Do()
        {
            base.Do(); //Do the base Do() function that ActionMove inherits from in ActionBase
            try
            {   if (inputArray.Length < 2)
                {
                    Console.WriteLine("You are currently at: " + currentPlayer.CurrentLoc.Name + "\n" + currentPlayer.CurrentLoc.Description);
                }
                else
                {
                    for (int i = 0; i < inputArray.Length; i++)
                    {

                        switch (inputArray[i].ToLower()) //TODO: 
                        {
                            default:
                                break;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Debug.Log("Fix Your Game Epic!" + "\n" + ex.ToString());
            }
            //base.Do();
        }
    }
}