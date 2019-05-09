using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Game
    {
        private Player p1;
        private List<Location> map;
        public bool GameOver = false;


        public Game(List<Location> map, Player newPlayer)
        {

            /*
            locations.Add(new Location("Clearing", "", 0, 1, 0));
            locations.Add(new Location("Front of House", "", 0, 2, 0));
            locations.Add(new Location("House Hall", "", 0, 3, 0));
            locations.Add(new Location("House Kitchen", "", 0, 4, 0));
            locations.Add(new Location("House Laundry", "", 0, 5, 0));
            */      
            this.map = map;
            p1 = newPlayer;
            p1.CurrentGame = this;
            //p1 = new Player("Me", "Me", "It's you, the hero of our story", map[0]); //always set to start location

            /*
            TODO:
            Add Inventory System
            More Dynamic Actions System
            NPC's
           */
        }

        public void Run()
        {

            Console.Clear();
            while (!GameOver && !Globals.exitRequested) //Main game loop
            {
                ActionBase currentAction;

                //Show current game state
                DisplayState();

                //Process Input
                currentAction = ProcessInput();
                //Update Game
                //TODO: Create ActionProcessing Classes and call one of them here
                currentAction.Do(); 

                //Show output to player
                //Show player current location
               
            }
        }

        public ActionBase ProcessInput()
        {
            //Get player input
            
            bool goodInput = false;
            Actions validAction = Actions.Blank;
            string input = "";
            string[] inputArray = { };

            do
            {
                Console.Write("Please enter a command: ");
                input = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(input))
                {
                    input = input.Trim();
                    inputArray = input.Split(' ');
                    goodInput = GetAction(inputArray, out validAction);
                }
                else
                {
                    Console.WriteLine("I don't understand that");
                }
                if(!goodInput)
                {
                    Console.WriteLine("I don't understand that");
                }
            } while (!goodInput);

            switch(validAction)
            {
                case Actions.Move:
                    return new ActionMove(inputArray, p1);
                //case Actions.Attack:
                //return new ActionAttack();
                case Actions.Look:
                    return new ActionLook(inputArray, p1);
                case Actions.Exit:
                    return new ActionExit(inputArray, this);
                case Actions.Help:
                    return new ActionHelp();
                default:
                    break;
            }
            return null;
           
            //if "move" then look at next index and see if its a direction and then move the palyer that way
            //move east
            //e
            //move e
            //move left

        }

        private void DisplayState()
        { 
            //Show the current location
            Console.WriteLine(p1.CurrentLoc.name);
            if(p1.CurrentLoc.newLoc)
            {
                Console.WriteLine(p1.CurrentLoc.description);
                p1.CurrentLoc.newLoc = false;
            }
        }

        private void LinkLocations()
        {

        }
        //Location List
        //Monsters
        //Items list

        bool GetAction(string[] inputArray, out Actions actionToDo)    //>move east
        {
            actionToDo = Actions.Blank;

            foreach (string s in inputArray)
            {

                string sProcessed = s.ToLower();
                if (sProcessed.Equals("north") || sProcessed.Equals("south") || sProcessed.Equals("east") || sProcessed.Equals("west") || sProcessed.Equals("up") || sProcessed.Equals("down"))
                {
                    sProcessed = "move";
                }
                switch (sProcessed)
                {
                    case "move" :
                        actionToDo = Actions.Move;
                        return true;
                    case "look" :
                        actionToDo = Actions.Look;
                        return true;
                    case "exit":
                        actionToDo = Actions.Exit;
                        return true;
                    case "help":
                        actionToDo = Actions.Help;
                        return true;
                    case "put":
                        //actionsToDo = Actions.MoveItem;
                        return true;
                    case "hit":
                        //actionToDo = Actions.Attack;
                        return true;
                    default:
                        break;

                }

            }
            return false;
        }

    }
}

/*Add Action UseItem
    Determine if the player wants to use this action
    Create an instance of this action
    Action needs to figure out what player is trying to use
    Action call the item's Use()
    Action check single use and destroy item if necessary
*/