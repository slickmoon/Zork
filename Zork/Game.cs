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
        private List<Location> locations;
        public bool gameOver = false;


        public Game()
        {

            locations.Add(new Location("Clearing", "", 0, 1, 0));
            locations.Add(new Location("Front of House", "", 0, 2, 0));
            locations.Add(new Location("House Hall", "", 0, 3, 0));
            locations.Add(new Location("House Kitchen", "", 0, 4, 0));
            locations.Add(new Location("House Laundry", "", 0, 5, 0));
            p1 = new Player("Me", "Me", "It's you, the hero of our story", locations[0]); //always set to start location
        }

        public void Run()
        {

            while (!gameOver) //Main game loop
            {
                Actions actionToDo;
                //Process Input
                actionToDo = ProcessInput();
                //Update Game
                //TODO: Create ActionProcessing Classes and call one of them here

                //Show output to player
                //Show player current location
                //Console.WriteLine(p1.CurrentLoc.name);
            }
        }

        public Actions ProcessInput()
        {
            //Get player input
            
            bool goodInput = false;
            Actions validAction = Actions.Blank;
            string input = "";

            do
            {
                Console.Write("Please enter a command: ");
                input = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(input))
                {
                    input = input.Trim();
                    goodInput = GetAction(input, out validAction);
                }
                else
                {
                    Console.WriteLine("I don't understand that");
                }

            } while (!goodInput);

            return validAction;

            //TODO: Parse input to find out what the player wants to do
            //Split into a string array, look at the first index and decide what to do
            //if "move" then look at next index and see if its a direction and then move the palyer that way
            //move east
            //e
            //move e
            //move left

        }

        private void LinkLocations()
        {

        }
        //Location List
        //Monsters
        //Items list

        bool GetAction(string input, out Actions actionToDo)    //>move east
        {

            Actions thisAction;
            if (input.Contains("move", StringComparison.CurrentCultureIgnoreCase)) 
            {
                thisAction  = Actions.Move;
            }

            switch(thisAction)
            {
                case Actions.Move:
                    Player.Move(direction);
                break;
            }
        }

    }
}