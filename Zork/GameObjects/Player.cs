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

        public static void Move(Directions newdirection) 
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
            catch (NullReferenceException ex)
            {
                //if the location doesn't exist, then dont move there
                Console.WriteLine("There is a wall there");
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
            CurrentLoc = newLoc;
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
                if(currentLoc.newLoc)
                {
                    Console.WriteLine(currentLoc.description);
                }
                currentLoc.newLoc = false;
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
