using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class BuildInOven : ElectricalOven
    {
        public BuildInOven(bool hasCleaningFunctionality, List<string> accessories)
            : base()
        {
            _hasCleaningFunctionality = hasCleaningFunctionality;
            _accessories = accessories;
        }

        public BuildInOven(bool hasCleaningFunctionality, string[] accessories)
           : this(hasCleaningFunctionality, new List<string>(accessories))
        {       
        }

        private List<string> _accessories;
        public List<string> Accessories
        {
            get
            {
                return _accessories;
            }
        }

        private bool _hasCleaningFunctionality;
        public bool HasCleaningFunctionality
        {
            get
            {
                return _hasCleaningFunctionality;
            }
        }

        public override SmileySystem Smiley
        {
            get
            {
                return HasCleaningFunctionality ? SmileySystem.Glad : SmileySystem.Ligeglad;
            }
        }
    }
}
