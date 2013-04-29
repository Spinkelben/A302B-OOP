using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class BuildInOven : ElectricalOven
    {
        

        

        /// <summary>
        /// Liste med tilbehør.
        /// </summary>
        private List<string> _accessories;

        /// <summary>
        /// Property der holder styr på tilbehør.
        /// </summary>
        public List<string> Accessories
        {
            get
            {
                return _accessories;
            }
        }

        /// <summary>
        /// Har rensefunktion ja/nej?
        /// </summary>
        private bool _hasCleaningFunctionality;
        
        /// <summary>
        /// Property der holder styr på om ovnen har indbygget rensefunktion eller ej.
        /// </summary>
        public bool HasCleaningFunctionality
        {
            get
            {
                return _hasCleaningFunctionality;
            }
        }

        /// <summary>
        /// Implementation af SmileySystem.
        /// </summary>
        public override SmileySystem Smiley
        {
            get
            {
                return HasCleaningFunctionality ? SmileySystem.Glad : SmileySystem.Ligeglad;
            }
        }
        /// <summary>
        /// Laver et array af strings giver det til constructoren og udfylder tilbehørslisten med elementerne fra arrayet.
        /// </summary>
        /// <param name="name">Modelnavn</param>
        /// <param name="price">Pris i kr.</param>
        /// <param name="powerConsumption">Strømforbrug i kWh.</param>
        /// <param name="size">Størrelse i mm, længde, bredde højde.</param>
        /// <param name="volume">Volumen i liter.</param>
        /// <param name="hasCleaningFunctionality">Hvorvidt indbygningsovnen har rensefunktion eller ej.</param>
        /// <param name="accessories">Tilbehør</param>
        public BuildInOven(string name, decimal price, double powerConsumption, Dimensions size, int volume,
            bool hasCleaningFunctionality, string[] accessories)
            : this(name, price, powerConsumption, size, volume, hasCleaningFunctionality, new List<string>(accessories))
        {
        }
        /// <summary>
        /// Constructor til indbygningsovn.
        /// </summary>
        /// <param name="name">Modelnavn</param>
        /// <param name="price">Pris i kr.</param>
        /// <param name="powerConsumption">Strømforbrug i kWh.</param>
        /// <param name="size">Størrelse i mm, længde, bredde højde.</param>
        /// <param name="volume">Volumen i liter.</param>
        /// <param name="hasCleaningFunctionality">Hvorvidt ovnen har rensefunktion</param>
        /// <param name="accessories">Liste med tilbehør.</param>
        public BuildInOven(string name, decimal price, double powerConsumption, Dimensions size, int volume,
            bool hasCleaningFunctionality, List<string> accessories)
            : base(name, price, powerConsumption, size, volume)
        {
            _hasCleaningFunctionality = hasCleaningFunctionality;
            _accessories = accessories;
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
