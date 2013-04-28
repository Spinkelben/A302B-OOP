using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class MicrowaveOven : ElectricalOven
    {
        public MicrowaveOven(bool hasGrill, bool hasConvection) : base()
        {
            _hasGrill = hasGrill;
            _hasConvection = hasConvection;
        }

        private bool _hasGrill;
        public bool HasGrill
        {
            get
            {
                return _hasGrill;
            }
        }

        private bool _hasConvection;
        public bool HasConvection
        {
            get
            {
                return _hasConvection;
            }
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
