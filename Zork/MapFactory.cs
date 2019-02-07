using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zork
{
    class MapFactory
    {
        List<Location> map = new List<Location>();
        public void ReadMap()
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
                if (String.IsNullOrEmpty(s.Trim()))
                {
                    loadState = "linking";
                }
                switch(loadState)
                {
                    case "names":
                        if (!String.IsNullOrEmpty(s.Trim()))
                        {
                            string[] splitline = s.Split(',');

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
                                Console.WriteLine("Map load failed at line: " + linenumber + " inner exception: " + ex.Message);
                            }


                        }
                        break;
                    case "linking":
                        if (!String.IsNullOrEmpty(s.Trim()))
                        {
                            string[] splitline = s.Split(',');

                            try
                            {
                                string currMapID = splitline[0];
                                string nstring = splitline[1]; 
                                string estring = splitline[2];
                                string wstring = splitline[3];
                                string sstring = splitline[4];
                                string ustring = splitline[5];
                                string dstring = splitline[6];
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        break;
                }
                
            }
        }

        //TODO: Create LinkLocations(int l1, int l2);
    }


    //Locations
    //Player
    //Items
    //Creatures
    //C:\file.txt


}
