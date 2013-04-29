using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class StockLowEventListener
    {
        /// <summary>
        /// Reference til pubisher.
        /// </summary>
        private Inventory _inventory;
        /// <summary>
        /// Constructor til event listener.
        /// </summary>
        /// <param name="inventory">Publisher'en. Type: Inventory</param>
        public StockLowEventListener(Inventory inventory)
        {
            _inventory = inventory;
            _inventory.StockLow += new Inventory.StockLowHandler(StockLow);
        }
        /// <summary>
        /// Denne metode bliver kaldt når publisheren trigger en event.
        /// </summary>
        /// <param name="sender">Objectet som notificerer observeren. Publisher'en.</param>
        /// <param name="e">Event parametre. Formodeligt af type OnLowStockEventArgs.</param>
        public void StockLow(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(OnLowStockEventArgs))
            {
                OnLowStockEventArgs ActualE = (OnLowStockEventArgs)e;
                Console.WriteLine("WARNING low stock on " + ActualE.Name + ". Only " + ActualE.LeftInStock + " left.");
            }
        }
        /// <summary>
        /// Afmelder observeren og sletter referencen til lagerlisten. 
        /// </summary>
        public void Detach()
        {
            _inventory.StockLow -= new Inventory.StockLowHandler(StockLow);
            _inventory = null;
        }
    }
}
