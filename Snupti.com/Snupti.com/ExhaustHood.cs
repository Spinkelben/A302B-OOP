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

        /// <summary>
        /// Laver en ny instans af ExhaustHood
        /// </summary>
        /// <param name="name">Model navnet</param>
        /// <param name="price">Pris på produktet</param>
        /// <param name="type">Typer: Frithængt, Væghængt eller Indbygget</param>
        /// <param name="suctionCapacity">Sugestyrke kubikmeter i timen</param>
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

        /// <summary>
        /// enum som indeholder de forskellige typer af Emhætter.
        /// </summary>
        internal enum HoodType
        {
            Frithængt,
            Væghængt,
            Indbygget
        }

        /// <summary>
        /// Filter er Ja eller Nej.
        /// </summary>
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
        /// Filter er bool som har værdien 1 eller 0, afhængig af om emhætten har filter eller ej
        /// Bool'ens værdi svare til værdien i en enum.
        /// </summary>
        public override SmileySystem Smiley
        {
            get
            {
                return Filter ? SmileySystem.Ligeglad : SmileySystem.Sur;
            }
        }

        /// <summary>
        /// NoiseLevel tager dB ind som en int, checker om værdien er imellem 0 og 140 dB.
        /// </summary>
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

        /// <summary>
        /// Tager en streng ind, der er kun tre valide strenginput ("Frithængt", "Væghængt" eller "Indbygget")
        /// </summary>
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {   
                //Checker om input strengen er angivet i enum'en Hoodtype
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
        /// Tager en int ind, og ser om værdien er valid, altså over nul.
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
            result += Filter ? "Ja\n" : "Nej\n";
            result += "Smiley: " + Smiley + "\n";

            return result;
        }
    }
}

