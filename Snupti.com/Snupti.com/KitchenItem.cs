using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    abstract class KitchenItem : Item
    {
        public enum SmileySystem {Sur, Ligeglad, Glad};

        public abstract SmileySystem Smiley
        {
            get;
        }
    }
}   