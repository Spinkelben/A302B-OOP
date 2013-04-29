using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class ExhaustHood : KitchenItem
    {
        //fri, væg, indbygget
        private string _type;
        //kubic meter i timen
        private int _suctionCapacity;
        // ja og nej
        private bool _filter;
        private int _noiceLevel;

        internal enum HoodType
        {
            Frithængt,
            Væghængt,
            Indbygget
        }

        public bool Filter
        {
            get 
            {
                return _filter;
            }
            set
            {
                _filter = value;  
            }
        }

        public int Noicelevel
        {
            get 
            {
                return _noiceLevel;
            }
            set
            {
                if (value.IsBetween(0, 140))
                {
                    _noiceLevel = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("NoiceLevel", "NoiceLevel er ikke en gyldig  værdi.");
                }
            }
        }

        public string Type
        {
            get 
            {
                return _type;
            }
            set 
            {
                if (Enum.IsDefined(typeof(HoodType), value))
                {
                    _type = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("Type", "");
                }
            }
        }
           
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

        public static int GetKitchenSize(int suctionvalue) 
        {
            if (suctionvalue > 875)
            {
                return 35;
            }
            if (suctionvalue > 750 && suctionvalue < 1100)
            {
                return 30;
            }
            if (suctionvalue > 625 && suctionvalue < 900)
            {
                return 25;
            }
            if (suctionvalue > 500 && suctionvalue < 750)
            {
                return 20;
            }
            if (suctionvalue > 375 && suctionvalue < 750)
            {
                return 15;
            }
            if (suctionvalue > 250 && suctionvalue < 500)
            {
                return 10;
            }
            return 10;
        }  
    }
}