using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    abstract class Item
    {
        private string _name;
        private decimal _price;
        private static Range<int> _noiseRange = new Range<int>(0 , 140);
        
        protected Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        /// <summary>
        /// Modelnavnet på varen.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("Name");
                }
                else if (value == "")
                {
                    throw new System.ArgumentException("Name", "Name må ikke være en tom streng \"\".");
                }
                else
                {
                    _name = value;
                }
            }
        }
        /// <summary>
        /// Prisen på varen i kr.
        /// </summary>
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Price", "Price may not be a negative number");
                }
                else
                {
                    _price = value;
                }
            }
        }

        protected Range<int> NoiseRange
        {
            get
            {
                return _noiseRange;
            }
        }

        
        /// <summary>
        /// Printer info om modellen i er læsbart format.
        /// </summary>
        /// <returns>Information om modellen i strengformat. Et felt pr. linje.</returns>
        public override string ToString()
        {
            string result = "Model: " + Name + "\n";
            result += "Pris: " + Price + " kr.\n";
            return result;
        }
    }

}