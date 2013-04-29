using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class Inventory : IEnumerable<InventoryEntry>
    {
        /// <summary>
        /// Lagerlisten.
        /// </summary>
        private List<InventoryEntry> _stock = new List<InventoryEntry>();
        /// <summary>
        /// Privat instans af Lagerliste objektet
        /// </summary>
        private static Inventory instance;
        /// <summary>
        /// Delegate type til at forbinde StockLow notifikationer.
        /// </summary>
        /// <param name="sender">Obketet der triggerede eventet.</param>
        /// <param name="e">Event parametre.</param>
        public delegate void StockLowHandler(object sender, EventArgs e);
        /// <summary>
        /// En event clienter kan bruge til at blive notificeret når varebeholdningen bliver lav.
        /// </summary>
        public event StockLowHandler StockLow;
        protected virtual void OnLowStock(EventArgs e) 
        {
            if (StockLow != null)
            {
                StockLow(this, e);
            }
        }
        /// <summary>
        /// Privat constructor.
        /// </summary>
        private Inventory()
        {
            /**/
        }
        /// <summary>
        /// Hvis lagerlisten ikke er instantieret, laver den en ny instans, ellers returnerers 
        /// den aktuelle instans. 
        /// </summary>
        /// <returns>Instansen af lagerlisten.</returns>
        public static Inventory GetInstance()
        {
            if (instance == null)
            {
                instance = new Inventory();
            }
            return instance;
        }
        /// <summary>
        /// Lav en beholdningsopgørelse.
        /// </summary>
        /// <returns>Beholdningsopgørelsen i streng format</returns>
        public string GetStatus()
        {
            string result = "";
            foreach (InventoryEntry i in _stock)
            {
                result += i.ToString() + "\n"; 
            }
            return result;
        }
        /// <summary>
        /// Tilføj en vare til lagerlisten. Hvis varen findes i forvejen opdateres antallet i beholdningen.
        /// </summary>
        /// <param name="item">Varen der skal tilføjes til listen</param>
        public void Add(Item item)
        {
            this.Add(item, 1, 10);
        }
        /// <summary>
        /// Tilføj et antal af en bestemt vare til lagerlisten. Den sætter den standard threshold.
        /// </summary>
        /// <param name="item">Den bestemte vare der tilføjes.</param>
        /// <param name="amount">Antallet af varer der skal tilføjes.</param>
        public void Add(Item item, int amount)
        {
            this.Add(item, amount, 10);
        }
        /// <summary>
        /// Tilføj et antal varer til lagerlisten. Hvis varen findes i forvejen opdateres antallet i beholdningen.
        /// </summary>
        /// <param name="item">Varen der skal tilføjes</param>
        /// <param name="amount">Antallet af varer der skal tilføjes</param>
        /// <exception cref="Exeption">Hvis der findes mere end en vare med det navn</exception>
        public void Add(Item item, int amount, int lowStockThreshold)
        {
            //Tjek om varen allerede findes i listen
            var items = _stock.Where(s => s.Item.Name == item.Name);
            if (items.Count() > 1)
            {
                throw new Exception("Mere end en type vare med det modelnavn");
            }
            //Tilføj varen
            if (items.Count() == 1)
            {
                items.ElementAt(0).Amount += amount;
            }
            else 
            {
                _stock.Add(new InventoryEntry(item, amount, lowStockThreshold));
            }
        }
        /// <summary>
        /// Tilføjer et antal varer til beholdningen af en allerede eksisterende vare.
        /// </summary>
        /// <param name="name">Modelnavnet som streng</param>
        /// <param name="amount">Antal værer der skal tilføjes.</param>
        /// <exception cref="Exeption">Hvis det findes flere modeller med det navn</exception>
        /// <exception cref="ArgumentExeption">Hvis der ikke findes en vare med det navn</exception>
        public void AddExisting(string name, int amount)
        {
            //Tjek om varen allerede findes i listen
            var items = _stock.Where(s => s.Item.Name == name);
            if (items.Count() > 1)
            {
                throw new Exception("Mere end en type vare med det modelnavn");
            }
            //Tilføj varen
            if (items.Count() == 1)
            {
                items.ElementAt(0).Amount += amount;
                //_stock.First(s => s.Item.Name == name).Amount += amount;                
            }
            else
            {
                throw new ArgumentException("name", "Der findes ikke en vare med det navn");
            }
           
        }
        /// <summary>
        /// Fjerner et antal varer fra lagerlisten.
        /// </summary>
        /// <param name="item">Varen der skal fjernes.</param>
        /// <param name="amount">Antallet af varer der skal fjernes.</param>
        /// <exception cref="Exeption">Hvis der findes mere end en vare med det navn.</exception>
        /// <exception cref="ArgumentExeption">Hvis der ikke findes en vare med det navn.</exception>
        public void Remove(Item item, int amount)
        {
            this.Remove(item.Name, amount);
        }
        /// <summary>
        /// Fjerner et antal varer fra lagerlisten.
        /// </summary>
        /// <param name="name">navnet på varen der skal fjernes.</param>
        /// <param name="amount">Antallet af varen der skal fjernes.</param>6
        /// <exception cref="Exception">Mere end en type vare med det navn.</exception>
        /// <exception cref="ArgumentExeption">Kunne ikke finde en vare med det navn.</exception>
        public void Remove(string name, int amount)
        {
            //Tjek om varen allerede findes i listen
            var items = _stock.Where(s => s.Item.Name == name);
            if (items.Count() > 1)
            {
                throw new Exception("Mere end en type vare med det modelnavn");
            }
            //Fjerner varen
            if (items.Count() == 1)
            {
                items.ElementAt(0).Amount -= amount;
                if (items.ElementAt(0).Amount < items.ElementAt(0).LowStockThreshold)
                {
                    EventArgs e = new OnLowStockEventArgs(items.ElementAt(0).Amount, items.ElementAt(0).Item.Name);
                    OnLowStock(e);
                }
            }
            else
            {
                throw new ArgumentException("item", "Varen findes ikke i systemet");
            }
        }
        /// <summary>
        /// Fjerner en vare helt fra lagerlisten. De andre metoder ændrer kun antallet af en bestemt vare.
        /// Den findes stadig i listen selvom der kun er nul varer tilbage. Varen bliver fjerenet helt, 
        /// uanset hvor mange der er tilbage på lageret.
        /// </summary>
        /// <param name="item">Varen der skal fjernes.</param>
        /// <exception cref="Exception">Der er mere end en vare med det navn.</exception>
        /// <exception cref="ArgumentExeption">Varen kunne ikke findes i systmet.</exception>
        public void RemoveFromDatabase(Item item)
        {
            //Tjek om varen allerede findes i listen
            var items = _stock.Where(s => s.Item.Name == item.Name);
            if (items.Count() > 1)
            {
                throw new Exception("Mere end en type vare med det modelnavn");
            }
            //Tilføj varen
            if (items.Count() == 1)
            {
                _stock.Remove(items.ElementAt(0));
            }
            else
            {
                throw new ArgumentException("item", "Varen findes ikke i systemet");
            }
        }

        /// <summary>
        /// Søgefunktion der finder alle varer hvis navn matcher en angivet søgestreng.
        /// </summary>
        /// <param name="name">Navn</param>
        /// <returns>foundItems</returns>
        public List<Item> SearchForName(string name)
        {
            List<Item> foundItems = new List<Item>();
            foreach (InventoryEntry inv in _stock.Where(invEntry => invEntry.Item.Name == name))
            {
                foundItems.Add(inv.Item);
            }
            return foundItems;
        }

        /// <summary>
        /// Returner en liste af produkter der ligger i mellem to givede værdier, som bliver sendt med.
        /// </summary>
        public List<InventoryEntry> SortedForPrice(Range<decimal> range) 
        {
            List<InventoryEntry> PriceSortedList = new List<InventoryEntry>();
            IEnumerable<InventoryEntry> items = PriceSortedList.Where(p => range.Contains(p.Item.Price));
            return PriceSortedList;
        }

        /// <summary>
        /// Søgefunktion der finder alle tørretumblere med et angivet energimærke.
        /// </summary>
        /// <param name="rating">Energiklasse</param>
        /// <returns>foundItems</returns>
        public List<Item> SearchForEnergyRating(EnergyRating rating)
        {
            List<Item> foundItems = new List<Item>();
            foreach (InventoryEntry inv in _stock.Where(invEntry => invEntry.Item is Dryer && ((Dryer)(invEntry.Item)).GetEnergyRating() == rating))
            {
                foundItems.Add(inv.Item);
            }
            return foundItems;
        }

        /// <summary>
        /// Søgefunktion der finder alle varer der har en angivet smiley.
        /// </summary>
        /// <param name="smiley">Smileyordning</param>
        /// <returns>foundItems</returns>
        public List<Item> SearchForSmiley(KitchenItem.SmileySystem smiley)
        {
            List<Item> foundItems = new List<Item>();
            foreach (InventoryEntry inv in _stock.Where(invEntry => invEntry.Item is KitchenItem && ((KitchenItem)(invEntry.Item)).Smiley == smiley))
            {
                foundItems.Add(inv.Item);
            }
            return foundItems;
        }

        /// <summary>
        /// Implementerer iteratoren der går fra index 0 til sidste element i listen.
        /// </summary>
        /// <returns>Iteratoren.</returns>
        public IEnumerator<InventoryEntry> GetEnumerator()
        {
            for (int i = 0; i < _stock.Count(); i++)
            {
                yield return _stock[i];
            }
        }
        /// <summary>
        /// Implementerer IEnumerable
        /// </summary>
        /// <returns>Standard iteratoren</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Gennemgår elementerne fra lav index til høj. Dette er standard opførslen, derfor returnerer 
        /// den bare sig selv.
        /// </summary>
        public IEnumerable<InventoryEntry> LowToHigh
        {
            get
            {
                return this;
            }
        }
        /// <summary>
        /// Gennemgår elementern fra høj index til lav.
        /// </summary>
        public IEnumerable<InventoryEntry> HighToLow
        {
            get
            {
                for (int i = _stock.Count() - 1; i >= 0; i--)
                {
                    yield return _stock[i];
                }
            }
        }

    }
}
