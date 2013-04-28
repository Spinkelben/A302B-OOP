using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    abstract class KitchenItem : Item
    {
        public KitchenItem(string name, int price)
            : base(name, price)
        {
        }

        /// <summary>
        /// Enum med de tre smileys - Sur, Ligeglad & Glad.
        /// </summary>
        public enum SmileySystem {Sur, Ligeglad, Glad};

        public abstract SmileySystem Smiley
        {
            get;
        }
    }
}   