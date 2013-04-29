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

        /// <summary>
        /// Udprinting af information om modellerne
        /// </summary>
        /// <returns>Information om modellen i strengformat. Et felt pr. linje.</returns>
        public override string ToString()
        {
            string result;
            string ovenSpecs = base.ToString();
            result = ovenSpecs;
            result += "Type: Mikroovn\n";
            result += "Energiklasse: " + GetEnergyRating() + "\n";
            result += "Har varmluft: " + HasConvection.ToString();
            result += "Har Grill: " + HasGrill.ToString();
            result += "SmileyRating: " + Smiley.ToString();
    
            return result;
        }
    }
}
