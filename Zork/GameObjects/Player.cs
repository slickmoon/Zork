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

        void Move(Directions newdirection)  //TODO: refactor
        {
            try
            {
                switch (newdirection)
                {
                    case Directions.East:
                        break;
                    case Directions.West:
                        break;
                    case Directions.North:
                       
                        break;
                    case Directions.South:
                        
                        break;
                    case Directions.Up:
                        
                        break;
                    case Directions.Down:
                        
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
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Movement finished");
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
