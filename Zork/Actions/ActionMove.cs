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
        MovementTypes moveType = MovementTypes.Walking;

        public ActionMove(string[] inputArray, Player currentPlayer)
        {
            this.inputArray = inputArray;

            this.currentPlayer = currentPlayer;
        }

        public ActionMove(string[] inputArray, Player currentPlayer, MovementTypes moveType) 
        {
            this.inputArray = inputArray;

            this.currentPlayer = currentPlayer;
            this.moveType = moveType;
        }   

        public override void Do()
        {
            base.Do(); //Do the base Do() function that ActionMove inherits from in ActionBase
            try
            {
                switch(moveType) 
                {
                    case MovementTypes.Walking:

                        for (int i = 0; i < inputArray.Length; i++)
                        {

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
                    break;

                    case MovementTypes.Teleport:

                        int mapID;

                        try
                        {
                            mapID = Convert.ToInt32(inputArray[1]);
                        } catch (FormatException) 
                        {
                            Debug.Error("Failed to read mapID because it ws not a number");
                        }

                    break;

                    default:
                        for (int i = 0; i < inputArray.Length; i++)
                        {

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
                    break;
                            
                }
            }
            catch (Exception)
            {
                Debug.Log("Fix Your Game Epic!");
            }
            //base.Do();
        }
    }
}