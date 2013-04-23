using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class VentedDryer : Dryer
    {
        /// <summary>
        /// Liste med grænseværdier for energiklasserne for en aftrækstørretumbler.
        /// </summary>
        private static List<double> _ventedDryerThreshold = new List<double>() { 0.51, 0.59, 0.67, 0.75, 0.83, 0.91 };
        /// <summary>
        /// Felt der husker om der følger en slange med tørretumbleren.
        /// </summary>
        private bool _pipeIncluded;
        /// <summary>
        /// Property til at sætte feltet det husker om der følger en slange med.
        /// </summary>
        public bool PipeIncluded
        {
            get
            {
                return _pipeIncluded;
            }
            set
            {
                _pipeIncluded = value;
            }
        }
        /// <summary>
        /// Laver en ny instans af aftrækstørretumbleren.
        /// </summary>
        /// <param name="name">Modelnavn.</param>
        /// <param name="price">Pris i kr.</param>
        public VentedDryer(string name, int price)
            : this(name, price, 1.0, 1, new Dimensions(), 1, 1, true)
        {
            /*Empty*/
        }
        /// <summary>
        /// Laver en ny instans af aftrækstørretumbleren.
        /// </summary>
        /// <param name="name">Modelnavn.</param>
        /// <param name="price">Pris i kr.</param>
        /// <param name="powerConsumption">Strømforbrug i kWh per tørrecyklus.</param>
        /// <param name="capacity">kapacitet i kg.</param>
        /// <param name="size">Dimentioner som Dimentions object.</param>
        /// <param name="noiseLevel">Støjniveau i dB.</param>
        /// <param name="dryingTime">Tørretid i minutter.</param>
        /// <param name="pipeIncluded">Hvorvidt der følger en slange med.</param>
        public VentedDryer(string name, int price, double powerConsumption, int capacity, Dimensions size,
            int noiseLevel, int dryingTime, bool pipeIncluded) : this(name, price, powerConsumption, capacity, size.Length,
            size.Width, size.Height, noiseLevel, dryingTime, pipeIncluded)
        {
            /*Empty*/
        }
        /// <summary>
        /// Laver en ny instans af Kondenstørretumbleren.
        /// </summary>
        /// <param name="name">Model Navn.</param>
        /// <param name="price">Pris i kr.</param>
        /// <param name="powerConsumption">Strømforbrug i kWh per tørrecyklus.</param>
        /// <param name="capacity">Kapacitet i kg.</param>
        /// <param name="length">Længde i mm.</param>
        /// <param name="width">Bredde i mm.</param>
        /// <param name="height">Højde i mm.</param>
        /// <param name="noiseLevel">Støjniveau i dB.</param>
        /// <param name="dryingTime">Tørretid i minutter.</param>
        /// <param name="pipeIncluded">Hvorvidt der følger en slange med.</param>
        public VentedDryer(string name, int price, double powerConsumption, int capacity, int length,
            int width, int height , int noiseLevel, int dryingTime, bool pipeIncluded)
        {
            Name = name;
            Price = price;
            PowerConsumption = powerConsumption;
            Capacity = capacity;
            Dimensions size = new Dimensions(length, width, height);
            Size = size;
            NoiseLevel = noiseLevel;
            DryingTime = dryingTime;
            PipeIncluded = pipeIncluded;
        }
        /// <summary>
        /// Beregner tørretumbleres energiklasse.
        /// </summary>
        /// <returns>Energiklassen som en energyRating enum.</returns>
        public override EnergyRating GetEnergyRating()
        {
            return TumbleDryerEnergyRating(_ventedDryerThreshold);
        }
    }
}
