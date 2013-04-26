using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class MicrowaveOven : ElectricalOven
    {
        public MicrowaveOven(bool hasGrill) : base()
        {
            _hasGrill = hasGrill;
        }

        private bool _hasGrill;
        public bool HasGrill
        {
            get;
        }

        public override SmileySystem Smiley
        {
            get
            {
                return HasGrill ? SmileySystem.Ligeglad : SmileySystem.Sur;
            }
        }
    }
}
