﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Game
    {
        public Player p1;
        public List<Location> Map;
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
            this.Map = map;
            p1 = newPlayer;
            p1.CurrentGame = this;
            //p1 = new Player("Me", "Me", "It's you, the hero of our story", map[0]); //always set to start location

            /*
            TODO:
            Combat
            Key
           */
        }

        public void Run()
        {
            while (!GameOver && !Globals.exitRequested) //Main game loop
            {
                ActionBase currentAction;

                //Show current game state
                DisplayState();

                //Process Input
                currentAction = ProcessInput();
                Console.Clear();
                //Update Game

                currentAction.Do(); //Run the players input
                p1.CurrentLoc.Do(); //Run the location's tasks

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
                case Actions.Teleport:
                     return new ActionMove(inputArray,p1,MovementTypes.Teleport);
                //case Actions.Attack:
                //return new ActionAttack();
                case Actions.Look:
                    return new ActionLook(inputArray, p1);
                case Actions.Exit:
                    return new ActionExit(inputArray, this);
                case Actions.Help:
                    return new ActionHelp();
                case Actions.Use:
                    return new ActionUse(inputArray, p1);
                case Actions.Drop:
                    return new ActionMoveItem(inputArray, p1, ItemMovements.Drop);
                case Actions.Take:
                    return new ActionMoveItem(inputArray, p1, ItemMovements.Take);
                case Actions.Put:
                    return new ActionMoveItem(inputArray, p1, ItemMovements.Put);
                case Actions.Attack:
                    return new ActionAttack(inputArray,p1);
                default:
                    break;
            }
            return new ActionBase();           
            //if "move" then look at next index and see if its a direction and then move the palyer that way
            //move east
            //e
            //move e
            //move left

        }

        private void DisplayState()
        { 
            //Show the current location
            Console.WriteLine("\nYou are at: " + p1.CurrentLoc.Name);
            if(p1.CurrentLoc.newLoc)
            {
                Console.WriteLine(p1.CurrentLoc.Description);
                p1.CurrentLoc.newLoc = false;
            }

            p1.CurrentLoc.Inventory.PrintItems();

            foreach(GateBase g in p1.CurrentLoc.Gates)
            {
                if (g.IsActive)
                {
                    Console.WriteLine(g.Description);
                }
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
                    case "teleport" :
                        actionToDo = Actions.Teleport;
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
                    case "use":
                        actionToDo = Actions.Use;
                        return true;
                    case "put":
                        actionToDo = Actions.Put;
                        return true;
                    case "drop":
                        actionToDo = Actions.Drop;
                        return true;
                    case "hit":
                        actionToDo = Actions.Attack;
                        return true;
                    case "take":
                        actionToDo = Actions.Take;
                        return true;

                    default:
                        break;

                }

            }
            return false;
        }

    }
}