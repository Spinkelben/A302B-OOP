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
        private int _kitchenSize;

        public ExhaustHood(string name, int price, string type, int suctionCapacity, bool filter, int noiseLevel)
        {
            Name = name;
            Price = price;
            Type = type;
            SuctionCapacity = suctionCapacity;
            Filter = filter;
            Noicelevel = noiseLevel;
        }

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

        public override SmileySystem Smiley
        {
            get
            {
                return Filter ? SmileySystem.Sur : SmileySystem.Ligeglad;
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
                        _kitchenSize = GetKitchenSize(SuctionCapacity);
                    }
                else
                {
                    throw new System.ArgumentOutOfRangeException("SuctionCapacity", "Suctioncapacity kan ikke være negativ");
                }
            }
        }

        public int KitchenSize 
        {
            get 
            {
                return _kitchenSize;
            }
        }

        public static int GetKitchenSize(int suctionvalue) 
        {
            if (suctionvalue > 875)
            {
                return 35;
            }
            if (suctionvalue > 750)
            {
                return 30;
            }
            if (suctionvalue > 625)
            {
                return 25;
            }
            if (suctionvalue > 500)
            {
                return 20;
            }
            if (suctionvalue > 375)
            {
                return 15;
            }
            if (suctionvalue > 250)
            {
                return 10;
            }
            return 10;
        }  

        public override string ToString()
        {
            string result;
            string ExHood = base.ToString();
            result = ExHood;
            result += "Type: " + Type + "\n";
            result += "Støjniveau: " + Noicelevel +" dB\n";
            result += "Sugekapacitet: " + SuctionCapacity + " m\u00B3/t\n";
            result += "Anbefalet max køkkenstørelse: " + KitchenSize + " m\u00B2\n";
            result += "Filter: ";
            if (Filter == false)
            {
                result += "Ja\n";
            }
            else
            {
                result += "Nej\n";
            }
            result += "Smiley: " + Smiley + "\n";

            return result;
        }

    }
}

