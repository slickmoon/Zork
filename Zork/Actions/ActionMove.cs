using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class ActionMove : ActionBase
    {
        string[] inputArray;
        Player currentPlayer;
        
        public ActionMove(string[] inputArray, Player currentPlayer)
        {
            this.inputArray = inputArray;

            this.currentPlayer = currentPlayer;
        }

        public new void Do()
        {
            try
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
         //nintendo
                    switch(inputArray[i].ToLower())
                    {
                        case "east":
                            currentPlayer.Move(Directions.East);
                            break;
                        case "west":
                            currentPlayer.Move(Directions.West);
                            break;
                        case "north":
                            currentPlayer.Move(Directions.North);
                            break;
                        case "south":
                            currentPlayer.Move(Directions.South);
                            break;
                        case "up":
                            currentPlayer.Move(Directions.Up);
                            break;
                        case "down":
                            currentPlayer.Move(Directions.Down);
                            break;
                            //up up down down left right left right a b start select
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Debug.Log("Fix Your Game Epic!");
            }
            //base.Do();
        }
    }
}