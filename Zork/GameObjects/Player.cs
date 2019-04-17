using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Player : GameObject
    {
        private int hitPoints = 10;
        private Location currentLoc;

        public Player(string name, string shortname, string description, Location startLoc) : base(name, shortname, description)
        {
            currentLoc = startLoc;
        }

        public void Move(Directions newdirection)   //TODO: update this function so that the player can't move to a blank location (mapID = 0)
        {
            try
            {
                switch (newdirection)
                {
                    case Directions.East:
                        Move(CurrentLoc.eastLoc);
                        break;
                    case Directions.West:
                        Move(CurrentLoc.westLoc);
                        break;
                    case Directions.North:
                        Move(CurrentLoc.northLoc);
                        break;
                    case Directions.South:
                        Move(CurrentLoc.southLoc);
                        break;
                    case Directions.Up:
                        Move(CurrentLoc.upLoc);
                        break;
                    case Directions.Down:
                        Move(CurrentLoc.downLoc);
                        break;
                    default:
                        Console.WriteLine("That's not a location");
                        break;
                }
            }
            catch (NullReferenceException)
            {
                //if the location doesn't exist, then dont move there
                Console.WriteLine("There is a wall there");
                //TODO: Put the player back to somewhere valid if they are somewhere invalid???
            }
            catch(Exception ex)
            {
                Debug.Error(ex.Message);
            }
            finally
            {
                Debug.Log("Movement finished"); //Movement finished
            }
        }


        void Move(Location newLoc)
        {
            if(newLoc != null)
            {
                if (newLoc.mapID != 0)
                {
                    CurrentLoc = newLoc;
                }
                else
                {
                    Console.WriteLine("There is a wall there");
                    //Debug.Log("Attempted to move to mapid 0");
                }
            }
            else
            {
                Debug.Log("Attempted to move to a null mapid");
            }
              
        }

        public Location CurrentLoc
        {
            get
            {
                return currentLoc;
            }
            set
            {
                currentLoc = value;
            }
        }
        
        public int Health
        {
            get
            {
                return hitPoints;
            
            }
            set
            {
                hitPoints = value;
                Console.WriteLine("Your health is now: " + hitPoints);
            }
        }
        //TODO: Add Look method to look at items


    }


}
