using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class BuildInOven : ElectricalOven
    {
        public BuildInOven(bool hasCleaningFunctionality) : base()
        {
            _hasCleaningFunctionality = hasCleaningFunctionality;
        }

        private bool _hasCleaningFunctionality;
        public bool HasCleaningFunctionality
        {
            get;
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
