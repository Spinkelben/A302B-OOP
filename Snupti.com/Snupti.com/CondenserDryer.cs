using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class CondenserDryer : Dryer
    {
        /// <summary>
        /// Listen med grænseværdier for de forskellige energiklasser for denne type af hvidevare.
        /// Første element i listen angiver grænseværdien for energiklasse A, anden værdi B osv.
        /// </summary>
        private static List<double> _condenserDryerThreshold = new List<double>() { 0.55, 0.64, 0.73, 0.82, 0.91, 1.00 };
        /// <summary>
        /// Har varmepumpe ja/nej?
        /// </summary>
        private bool _heatPump;

        /// <summary>
        /// Property der husker om tørretumbleren har varmepumpe.
        /// </summary>
        public bool HeatPump
        {
            get
            {
                return _heatPump;
            }
            set 
            { 
                _heatPump = value; 
            }
        }


        /// <summary>
        /// Laver en ny instans af Kondenstørretumbleren.
        /// </summary>
        /// <param name="name">Modelnavn.</param>
        /// <param name="price">Pris i kr.</param>
        public CondenserDryer(string name, int price)
            : this(name, price, 1.0, 1, new Dimensions(), 1, 1)
        {
            /*Empty*/
        }
        /// <summary>
        /// Laver en ny instans af Kondenstørretumbleren.
        /// </summary>
        /// <param name="name">Modelnavn.</param>
        /// <param name="price">Pris i kr.</param>
        /// <param name="powerConsumption">Strømforbrug i kWh per tørrecyklus.</param>
        /// <param name="capacity">kapacitet i kg.</param>
        /// <param name="size">Dimentioner som Dimentions object.</param>
        /// <param name="noiseLevel">Støjniveau i dB.</param>
        /// <param name="dryingTime">Tørretid i minutter.</param>
        public CondenserDryer(string name, int price, double powerConsumption, int capacity, Dimensions size,
            int noiseLevel, int dryingTime) : this(name, price, powerConsumption, capacity, size.Length,
            size.Width, size.Height, noiseLevel, dryingTime)
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
        public CondenserDryer(string name, int price, double powerConsumption, int capacity, int length,
            int width, int height , int noiseLevel, int dryingTime)
        {
            Name = name;
            Price = price;
            PowerConsumption = powerConsumption;
            Capacity = capacity;
            Dimensions size = new Dimensions(length, width, height);
            Size = size;
            NoiseLevel = noiseLevel;
            DryingTime = dryingTime;
        }
        /// <summary>
        /// Override af GetEnergyRating() methoden, som beregner energiklassen for denne tørretumbler.
        /// </summary>
        /// <returns>EnergyRating. Energiklassen for denne kondenstørretumbler.</returns>
        public override EnergyRating GetEnergyRating()
        {
            return TumbleDryerEnergyRating(_condenserDryerThreshold);
        }
    }
}
