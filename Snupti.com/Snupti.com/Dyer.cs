using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class Dryer : Item
    {
        //kWh per tørrecyklus
        private double _powerConsumption;
        //Kg
        private int _capacity;
        private Dimentions _size;
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
        public Dimentions Size
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

    }
}