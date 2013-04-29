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

        /// <summary>
        /// Udprinting af information om modellerne
        /// </summary>
        /// <returns>Information om modellen i strengformat. Et felt pr. linje.</returns>
        public override string ToString()
        {
            string result;
            string ovenSpecs = base.ToString();
            result = ovenSpecs;
            result += "Type: Indbygningsovn\n";
            result += "Energiklasse: " + GetEnergyRating() + "\n";
            result += "Har rensefunktion: " + HasCleaningFunctionality.ToString();
            result += "Tilbehør: " + Accessories.ToString();
            result += "SmileyRating: " + Smiley.ToString();

            return result;
        }
    }
}
