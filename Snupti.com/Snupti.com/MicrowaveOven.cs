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
        /// Constructor til Mikroovnsklassen.
        /// </summary>
        /// <param name="name">Modelnavn.</param>
        /// <param name="price">Pris i kr.</param>
        /// <param name="powerConsumption">Strømforbrug.</param>
        /// <param name="size">Dimensioner i mm, længde, bredde, højde.</param>
        /// <param name="volume">Volumen i liter.</param>
        /// <param name="hasGrill">Hvorvidt mikroovnen har grillfunktion.</param>
        /// <param name="hasConvection">Hvorvidt mikroovnen har varmluft.</param>
        public MicrowaveOven(string name, decimal price, double powerConsumption, Dimensions size, int volume, 
            bool hasGrill, bool hasConvection) : base(name, price, powerConsumption, size, volume)
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
