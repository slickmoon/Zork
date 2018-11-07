using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class GameObject
    {
        public string name = "";
        public string shortName = "";
        public string description = "";

        public GameObject(string name, string shortname, string description)
        {
            this.name = name;
            this.shortName = shortname;
            this.description = description;           
        }
    }
}