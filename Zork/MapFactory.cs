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
        
        public void ReadMap()
        {
            string[] mapstring = File.ReadAllLines(@"../../Assets/map.txt");
            int linenumber = 0;

            for(int i = 0; i< 10; i++)
            {
                i++;
            }


            foreach(string s in mapstring)
            {
                linenumber++;
                if(s != null)
                {
                    string[] splitline = s.Split(',');

                    try
                    {
                        //string mapid = splitline[0];
                        string name = splitline[1];
                        string desc = splitline[2];

                        Location newLoc = new Location(name, desc);
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine("Map load failed at line: " + linenumber);
                    }

                    
                }
            }
        }
    }


    //Locations
    //Player
    //Items
    //Creatures
    //C:\file.txt


}
