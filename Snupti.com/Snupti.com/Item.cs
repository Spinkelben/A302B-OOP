using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class Item
    {
        private string _name;
        private int _price;

        public Item(string name, int price)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("Name");
            }
            else if (name == "")
            {
                throw new System.ArgumentException("Name", "Name må ikke være en tom streng \"\".");
            }
            else
            {
                _name = name;
            }
            _name = name;
            _price = price;
        }

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
        public int Price
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