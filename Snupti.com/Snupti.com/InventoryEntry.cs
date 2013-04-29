using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    internal class InventoryEntry
    {
        private int _amount;
        private Item _item;

        internal int Amount 
        {
            get 
            {
                return _amount;
            }
            set
            {
                if (value >= 0)
                {
                    _amount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Amount", "Kan ikke have færre end 0 varer på lager");
                }
            }
        }

        internal Item Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
            }
        }

        internal InventoryEntry(Item item) 
            :this(item, 1)
        {
            /*Empty*/
        }
        internal InventoryEntry(Item item, int amount)
        {
            Item = item;
            Amount = amount;
        }
    }
}
