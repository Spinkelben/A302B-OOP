using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{

    class Elovn : Item
    {
        private double _powerConsumption;
        private double _capacity;
        private Dimensions _size;

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
                    throw new System.ArgumentOutOfRangeException("PowerConsumption", "Kan ikke være mindre end 0");
                }
                else
                {
                    _powerConsumption = value;
                }
            }
        }

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
        
        public int Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (value < 0)
                {
                    _volume = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("Volume", "Volume kan ikke være mindre end 0");
                }
            }
        }
    }
}
