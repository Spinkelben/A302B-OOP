using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class Dyer : Item
    {
        private double _powerConsumption;
        private double _capacity;
        private Dimentions _size;
        /// <summary>
        /// Strømforbrug per tørrecyklus. 
        /// </summary>
        public double PowerConsumption
        {
            get
            {
                return _powerConsumption;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("PowerConsumption", "Powerconsumption cannot be less than zero");
                }
                else
                {
                    _powerConsumption = value;
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