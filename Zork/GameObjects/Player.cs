using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
  public class Player : GameObject
    {
        private int hitPoints = 10;
        private int maxHitPoints;
        private Location currentLoc;
        private Inventory inventory;

        public Game CurrentGame;

        public Player(string name, string shortname, string description, Location startLoc) : base(name, shortname, description)
        {
            maxHitPoints = hitPoints;
            currentLoc = startLoc;
            inventory = new Inventory("Bag","Bag");

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


        public void Move(Location newLoc)
        {
            if(newLoc != null)
            {
                if (newLoc.mapID != 0)
                {
                    if (CurrentLoc == newLoc)
                    {
                        Console.WriteLine("This place looks familiar....");
                    }
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

        public void Move(int mapID) 
        {
            foreach(Location l in CurrentGame.Map)
            {
                if(l.mapID == mapID)
                {
                    currentLoc = l;
                    return;
                }
            }
            Console.WriteLine("There is no location with mapID: " + mapID.ToString());

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

        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }

        public int Health
        {
            get
            {
                return hitPoints;
            }
        }
        
        public void AddHealth(int value)
        {
            hitPoints += value;
            if(hitPoints > maxHitPoints)
            {
                Console.WriteLine("Health restored to full!");
                hitPoints = maxHitPoints;
            }
            Console.WriteLine("Your health is now: " + hitPoints);
        }

        public void RemoveHealth(int value)
        {

            hitPoints -= value;
            if ((hitPoints-value) <= 0)
            {
                Console.WriteLine("You are dead!");
                CurrentGame.GameOver = true;
            }
            else
            {
                Console.WriteLine("Your health is now: " + hitPoints);
            }
        }
        //TODO: Add Look method to look at items


    }


}
