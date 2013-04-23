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

        public enum hoodtype
        {
            Frithængt,
            Væghængt,
            Indbygget
        }

        public string Type
        {
            get 
            {
                return _type;
            }
            set 
            {
                if ()
                {
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
            if (suctionvalue < 1300 ||suctionvalue > 875 && suctionvalue < 1300)
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