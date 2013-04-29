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
        private int _lowStockThreshold;
        /// <summary>
        /// Antallet af den bestemte vare der er på lager.
        /// </summary>
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
        /// <summary>
        /// Den bestemte vare der er på denne plads i lageret.
        /// </summary>
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
        /// <summary>
        /// Grænseværdien for hvornår der skal gives advarsler om lav varebeholdning.
        /// </summary>
        internal int LowStockThreshold
        {
            get
            {
                return _lowStockThreshold;
            }
            set
            {
                _lowStockThreshold = value;
            }
        }
        /// <summary>
        /// Instantierer en ny indgang i lagerlisten. Lægger 1 vare ind med en lav-varebeholdnings
        /// grænseværdi på 10.
        /// </summary>
        /// <param name="item">Varen der skal skrives på lagerlisten.</param>
        internal InventoryEntry(Item item)
            : this(item, 1, 10)
        {
            /*Empty*/
        }
        /// <summary>
        /// Instantier en ny indgang i lagerlisten. Sætter lav-varebeholdningsgrænseværdien til 10.
        /// </summary>
        /// <param name="item">Varen der skal skrives ind på lagerlisten.</param>
        /// <param name="amount">Antallet af den bestemte vare der skal skrives ind på lagerlisten.</param>
        internal InventoryEntry(Item item, int amount)
            : this(item, amount, 10)
        {
            /*Empty*/
        }
        /// <summary>
        /// Instantierer en ny indgang i lagerlisten.
        /// </summary>
        /// <param name="item">Varen der skal skrives ind på lagerlisten.</param>
        /// <param name="amount">Antallet af den bestemte vare der skal skrives ind på lagerlisten.</param>
        /// <param name="lowStockThreshold">Grænseværdien for hvornår der skal gives advarsel
        /// for lav varebeholdning.</param>
        internal InventoryEntry(Item item, int amount, int lowStockThreshold)
        {
            Item = item;
            Amount = amount;
            LowStockThreshold = lowStockThreshold;
        }

        public override string ToString()
        {
            return "Model: " + this.Item.Name + " Antal: " + this.Amount + " Lav-varebeholdningsgrænseværdi: " + this.LowStockThreshold;
        }
    }
}
