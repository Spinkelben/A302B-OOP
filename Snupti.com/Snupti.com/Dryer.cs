using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    abstract class Dryer : Item, IEnergyRating
    {
        /// <summary>
        /// kWh per tørrecyklus.
        /// </summary>
        private double _powerConsumption;
        /// <summary>
        /// Kapacitet i kg.
        /// </summary>
        private int _capacity;
        /// <summary>
        /// Dimentioner i mm. Højde, bredde og længde.
        /// </summary>
        private Dimensions _size;
        /// <summary>
        /// Støjniveau.
        /// </summary>
        private int _noise;
        /// <summary>
        /// Tørretid i minutter.
        /// </summary>
        private int _dryingTime;
        /// <summary>
        /// Strømforbrug per tørrecyklus. kWh.
        /// </summary>
        public double PowerConsumption
        {
            get
            {
                return _powerConsumption;
            }
            set
            {
                if (value > 0)
                {
                    _powerConsumption = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("PowerConsumption", "PowerConsumption skal være større end nul");
                    
                }
            }
        }
        /// <summary>
        /// Kapacitet i kg.
        /// </summary>
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (value > 0)
                {
                    _capacity = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("Capacity", "Capacity skal være større end 0");
                }
            }
        }
        /// <summary>
        /// Dimentioner i mm. Længde, bredde og højde.
        /// </summary>
        public Dimensions Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
        /// <summary>
        /// Støjniveau i decibal. Gyldige værdier: 0-140.
        /// </summary>
        public int NoiseLevel
        {
            get
            {
                return _noise;
            }
            set 
            {
                if (value.IsBetween(0, 140))
                {
                    _noise = value;
                }
            }
        }
        /// <summary>
        /// Tørretiden i minutter. Skal være større end eller lig 0.
        /// </summary>
        public int DryingTime
        {
            get 
            {
                return _dryingTime;
            }
            set
            {
                if (value >= 0)
                {
                    _dryingTime = value;
                }
            }
        }
        /// <summary>
        /// Returnerer det relative strømforbrug E, som bruges i energiklasseberegningerne.
        /// </summary>
        /// <returns>Double, det relative strømforbrug, E</returns>
        public double RelativePowerConsumption()
        {
            return _powerConsumption / _capacity;
        }
        /// <summary>
        /// Returnerer en enum EnergyRating med den pågældende energiklasse.
        /// </summary>
        /// <returns></returns>
        public abstract EnergyRating GetEnergyRating();
        
        //    return EnergyTables.GetCondenserDryerRating(0.5);
        
    }
}