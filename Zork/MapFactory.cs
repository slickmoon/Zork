using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zork
{
    /*
    class ItemLocations 
    {
        public int mapid;
        public Item item;
    } */

    public sealed class MapFactory
    {
        private static readonly MapFactory instance = new MapFactory();

        private List<Location> map = new List<Location>();

        private MapFactory()
        {

        }

        static MapFactory()
        {

        }

        public List<Location> ReadMap()
        {
            string[] mapstring = File.ReadAllLines(@"../../Assets/map.txt");
            int linenumber = 0;

            /*
            for(int i = 0; i< 10; i++)
            {

                i++;
            }
            */
            string loadState = "names";

            foreach(string s in mapstring)
            {
                linenumber++;
                if (String.IsNullOrEmpty(s.Trim()) && loadState.Equals("names"))
                {
                    loadState = "linking";
                } else if (String.IsNullOrEmpty(s.Trim()) && loadState.Equals("linking"))
                {
                    loadState = "items";
                }
                else if (String.IsNullOrEmpty(s.Trim()) && loadState.Equals("items"))
                {
                    loadState = "npc";
                    //finished
                }else if (String.IsNullOrEmpty(s.Trim()) && loadState.Equals("npc"))
                {
                    break;
                    //finished
                }
                
                switch(loadState)
                {
                    case "names":
                        if (!String.IsNullOrEmpty(s.Trim()))
                        {
                            string[] splitline = s.Split('|');
                            
                            try
                            {
                                string mapIDstring = splitline[0];
                                string name = splitline[1];
                                string desc = splitline[2];

                                int mapID = 99999;

                                if (!int.TryParse(mapIDstring, out mapID))
                                {
                                    throw new MapException("mapID for line " + linenumber + " is invalid, please check the map.txt file");
                                }

                                foreach (Location l in map)
                                {
                                    if (l.mapID == mapID)
                                    {
                                        throw new DuplicateMapIDException("mapID for line " + linenumber + " is a duplicate, please check the map.txt file");
                                    }
                                }

                                map.Add(new Location(mapID, name, desc));

                            }
                            catch (Exception ex)
                            {
                                Debug.Error("Map load failed at line: " + linenumber + " inner exception: " + ex.Message);
                                Console.WriteLine("Map load failed at line: " + linenumber + " inner exception: " + ex.Message);
                            }


                        }
                        break;
                    case "linking":
                        if (!String.IsNullOrEmpty(s.Trim()))
                        {
                            string[] splitline = s.Split('|');

                            try
                            {

                                int currMapID = ReadMapID(splitline[0],linenumber);
                                int northid = ReadMapID(splitline[1], linenumber); 
                                int eastid = ReadMapID(splitline[2], linenumber);
                                int southid = ReadMapID(splitline[3], linenumber);
                                int westid = ReadMapID(splitline[4], linenumber);
                                int upid = ReadMapID(splitline[5], linenumber);
                                int downid = ReadMapID(splitline[6], linenumber);


                                LinkLocations(currMapID, northid,Directions.North);
                                LinkLocations(currMapID, eastid, Directions.East);
                                LinkLocations(currMapID, westid, Directions.West);
                                LinkLocations(currMapID, southid, Directions.South);
                                LinkLocations(currMapID, upid, Directions.Up);
                                LinkLocations(currMapID, downid, Directions.Down);



                            }
                            catch (Exception ex)
                            {
                                Debug.Error(ex.Message);
                            }
                        }
                        break;
                    case "items":
                        if (!String.IsNullOrEmpty(s.Trim()))
                        {
                            string[] splitline = s.Split('|');
                            try
                            {
                                int itemLocationMapID = ReadMapID(splitline[0], linenumber);
                                string itemname = splitline[1];

                                Item item = null;

                                switch (itemname.ToLower())
                                {
                                    case "apple" :
                                        item = new Apple();

                                        foreach(Location l in map)
                                        {
                                            if (l.mapID == itemLocationMapID)
                                            {
                                                l.Inventory.AddItem(item);
                                                break;
                                            }
                                        }

                                        //itemLoactions.Add(setLoaction(item, itemLocationMapID));

                                        break;
                                    case "bag" :
                                    item = new Inventory("Bag","It's a bag!");

                                    foreach(Location l in map)
                                    {
                                        if (l.mapID == itemLocationMapID)
                                        {
                                            l.Inventory.AddItem(item);
                                            break;
                                        }
                                    }
                                    break;
                                    case "sword":
                                        item = new Sword();

                                        foreach (Location l in map)
                                        {
                                            if (l.mapID == itemLocationMapID)
                                            {
                                                l.Inventory.AddItem(item);
                                                break;
                                            }
                                        }
                                        break;
                                    default:
                                        break;

                                }


                            }
                            catch (Exception ex)
                            {
                                Debug.Error(ex.Message);
                            }
                        }
                        break;

                        case "npc":
                            
                        if (!String.IsNullOrEmpty(s.Trim()))
                        {
                            string[] splitline = s.Split('|');
                            try
                            {
                                int NPCLocationMapID = ReadMapID(splitline[0], linenumber);
                                string NPCname = splitline[1];

                                switch (NPCname.ToLower())
                                {
                                    case "goblin" :
                                        foreach(Location l in map)
                                        {
                                            if (l.mapID == NPCLocationMapID)
                                            {
                                                l.bots.Add(new Goblin(l));
                                                break;
                                            }
                                        }

                                        break;
                                    default:
                                        break;

                                }


                            }
                            catch (Exception ex)
                            {
                                Debug.Error(ex.Message);
                            }
                        }
                        break;

                    default:
                        break;
                }
                
            }
            return map;

        }

        /*
        ItemLocations setLoaction(Item item, int location)
        {
            ItemLocations outItem = new ItemLocations();

            outItem.item = item;
            outItem.mapid = location;

            return outItem;
        } */

        int ReadMapID(string newMapIDString, int linenumber)
        {
            if (!string.IsNullOrEmpty(newMapIDString))
            {           

                int mapID;
                if (!int.TryParse(newMapIDString, out mapID))
                {
                    throw new MapException("mapID for line " + linenumber + " is invalid, please check the map.txt file");
                }
                else
                {
                    return mapID;
                }
            } else
            {
                return 0;
            }        
            
        }
        //TODO: Create LinkLocations(int l1, int l2);
        void LinkLocations(int sourceloc, int targetloc, Directions dir)
        {
            if(!sourceloc.Equals(0) || !targetloc.Equals(0)) //Zero is not a valid location, don't do anything if the source or the target zero
            {
                Location Sourceloc = new Location(0, "", "");
                Location Targetloc = new Location(0, "", "");

                if (sourceloc == targetloc)
                {
                    throw new Exception("Cannot link a location to itself");
                }

                foreach (Location l in map)
                {
                    if (l.mapID.Equals(sourceloc))
                    {
                        Sourceloc = l;
                    }
                    if (l.mapID.Equals(targetloc))
                    {
                        Targetloc = l;
                    }
                }
                
                //loc1 and loc2 may be filled with a Location now

                //Sourceloc.northLoc = Targetloc;
                //Sourceloc.westLoc = Targetloc;


                switch (dir)
                {
                    case Directions.East:
                        Sourceloc.eastLoc = Targetloc;
                        break;
                    case Directions.North:
                        Sourceloc.northLoc = Targetloc;
                        break;
                    case Directions.West:
                        Sourceloc.westLoc = Targetloc;
                        break;
                    case Directions.South:
                        Sourceloc.southLoc = Targetloc;
                        break;
                    case Directions.Up:
                        Sourceloc.upLoc = Targetloc;
                        break;
                    case Directions.Down:
                        Sourceloc.downLoc = Targetloc;
                        break;
                }
            }
            

        }

        public static MapFactory Instance
        {
            get
            {
                return instance;
            }
        }
    }


    //Locations
    //Player
    //Items
    //Creatures
    //C:\file.txt
   

}
