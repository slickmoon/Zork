using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class ActionExit : ActionBase
    {
        string[] inputArray;
        Game currentGame;

        public ActionExit(string[] inputArray, Game currentGame)
        {
            this.inputArray = inputArray;
            this.currentGame = currentGame;
        }

        public override void Do()
        {
            base.Do(); //Do the base Do() function that ActionMove inherits from in ActionBase
            try
            {
                currentGame.GameOver = true;
                for (int i = 0; i < inputArray.Length; i++)
                {
                    switch (inputArray[i].ToLower()) //TODO: 
                    {
                        case "program" :
                            Globals.exitRequested = true;
                            break;
                        default:
                            break;
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