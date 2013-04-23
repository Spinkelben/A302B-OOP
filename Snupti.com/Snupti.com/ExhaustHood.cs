using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class ExhaustHood : Item
    {
        //fri, væg, indbygget
        private string _type;
        //kubic meter i timen
        private int _suctionCapacity;
        // ja og nej
        private bool _filter;
           
        public int SuctionCapacity 
        {
            get
            {
                return _suctionCapacity;
            }
            set
            {
                if (value > 0)
                    {
                        _suctionCapacity = value;
                    }
                else
                {
                    throw new System.ArgumentOutOfRangeException("SuctionCapacity", "Suctioncapacity kan ikke være negativ");
                }
            }
        }
    }
}
