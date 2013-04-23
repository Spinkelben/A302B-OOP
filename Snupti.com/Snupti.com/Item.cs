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
    }
}