using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class MicrowaveOven : ElectricalOven
    {
        /// <summary>
        /// Constructor med de to bools, hasGrill og hasConvection
        /// </summary>
        /// <param name="hasGrill">Hvorvidt mikroovnen har indbygget grill eller ej.</param>
        /// <param name="hasConvection">Hvorvidt mikroovnen har varmluft eller ej.</param>
        public MicrowaveOven(bool hasGrill, bool hasConvection) : base()
        {
            _hasGrill = hasGrill;
            _hasConvection = hasConvection;
        }

        /// <summary>
        /// Har Grill ja/nej?
        /// </summary>
        private bool _hasGrill;

        /// <summary>
        /// Property der holder styr på om ovnen har indbygget grill eller ej.
        /// </summary>
        public bool HasGrill
        {
            get
            {
                return _hasGrill;
            }
        }

        /// <summary>
        /// Har Varmluft ja/nej?
        /// </summary>
        private bool _hasConvection;

        /// <summary>
        /// Property der holder styr på om ovnen har varmluft eller ej.
        /// </summary>
        public bool HasConvection
        {
            get
            {
                return _hasConvection;
            }
        }

        /// <summary>
        /// Implementation af SmileySystem.
        /// </summary>
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
