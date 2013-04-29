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
        //kubikmeter i timen
        private int _suctionCapacity;
        // ja og nej
        private bool _filter;
        //dB 0 til 140
        private int _noiceLevel;
        //kvadratmeter
        

        /// <summary>
        /// Laver en ny instans af ExhaustHood
        /// </summary>
        /// <param name="name">Model navnet</param>
        /// <param name="price">Pris på produktet</param>
        /// <param name="type">Typer: Frithængt, Væghængt eller Indbygget</param>
        /// <param name="suctionCapacity"></param>
        /// <param name="filter">Ja eller Nej</param>
        /// <param name="noiseLevel">Støjniveau i dB 0 til 140 </param>
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

        /// <summary>
        /// 
        /// </summary>
        public override SmileySystem Smiley
        {
            get
            {
                return Filter ? SmileySystem.Ligeglad : SmileySystem.Sur;
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
                    throw new System.ArgumentOutOfRangeException("Type", "Typen er ikke en valid streng");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
                    throw new System.ArgumentOutOfRangeException("SuctionCapacity", "Suctioncapacity værdien kan ikke være negativ");
                }
            }
        }

        /// <summary>
        /// GetKitchenSize returnere en int afhængigt af Sugekapaciteten
        /// </summary>
        public int GetKitchenSize() 
        {
            if (SuctionCapacity > 875)
            {
                return 35;
            }
            if (SuctionCapacity > 750)
            {
                return 30;
            }
            if (SuctionCapacity > 625)
            {
                return 25;
            }
            if (SuctionCapacity > 500)
            {
                return 20;
            }
            if (SuctionCapacity > 375)
            {
                return 15;
            }
            if (SuctionCapacity > 250)
            {
                return 10;
            }
            return 10;
        }

        /// <summary>
        /// Returner en string som indeholder alle værdierne fra ExhaustHood klassen
        /// </summary>
        public override string ToString()
        {
            string result;
            string itemString = base.ToString();
            result = itemString;
            result += "Type: " + Type + "\n";
            result += "Støjniveau: " + Noicelevel + " dB\n";
            result += "Sugekapacitet: " + SuctionCapacity + " m\u00B3/t\n";
            result += "Anbefalet max køkkenstørelse: " + GetKitchenSize() + " m\u00B2\n";
            result += "Filter: ";
            if (Filter == true)
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

