using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class GameObject
    {
        public string Name = "";
        public string ShortName = "";
        public string Description = "";

        public GameObject(string name, string shortname, string description)
        {
            this.Name = name;
            this.ShortName = shortname;
            this.Description = description;     
        }

        public GameObject()
        {

        }
    }
}