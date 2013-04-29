using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    /// <summary>
    /// klasse der inderholder event parameterne til OnLowStock eventet.
    /// </summary>
    class OnLowStockEventArgs : EventArgs
    {
        private int _leftInStock;
        private string _name;
        /// <summary>
        /// Antal af den bestemte vare der er tilbage på lageret.
        /// </summary>
        public int LeftInStock
        {
            get
            {
                return _leftInStock;
            }
            set
            {
                _leftInStock = value;
            }

        }
        /// <summary>
        /// Navnet på varen der triggerede eventen.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        /// <summary>
        /// Skaber en ny instants af OnLowStockEventArgs.
        /// </summary>
        /// <param name="leftInStock">Antal af en besstemt vare der er tilbage.</param>
        /// <param name="name">Navnet på varen.</param>
        public OnLowStockEventArgs(int leftInStock, string name)
        {
            LeftInStock = leftInStock;
            Name = name;
        }
    }
}
