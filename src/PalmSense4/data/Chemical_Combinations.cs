using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmSense4
{
    public class Chemical_Combinations
    {
        private string type { get; set; }
        private string name { get; set; }
        private float molarmass { get; set; }

        public Chemical_Combinations(string type, string name, float molarmass)
        {
            this.type = type;
            this.name = name;
            this.molarmass = molarmass;
        }


        public string Type
        {
            get {
                return type;
            }

            set
            {
                type = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public float MolarMass
        {
            get
            {
                return molarmass;
            }

            set
            {
                molarmass = value;
            }
        }
    }
}
