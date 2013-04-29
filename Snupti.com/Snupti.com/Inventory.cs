using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class Inventory
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
                result += "Model: " + i.Item.Name + " Antal: " + i.Amount + "\n"; 
            }
            return result;
        }
        /// <summary>
        /// Tilføj en vare til lagerlisten. Hvis varen findes i forvejen opdateres antallet i beholdningen.
        /// </summary>
        /// <param name="item">Varen der skal tilføjes til listen</param>
        public void Add(Item item)
        {
            this.Add(item, 1);
        }
        /// <summary>
        /// Tilføj et antal varer til lagerlisten. Hvis varen findes i forvejen opdateres antallet i beholdningen.
        /// </summary>
        /// <param name="item">Varen der skal tilføjes</param>
        /// <param name="amount">Antallet af varer der skal tilføjes</param>
        /// <exception cref="Exeption">Hvis der findes mere end en vare med det navn</exception>
        public void Add(Item item, int amount)
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
                _stock.Add(new InventoryEntry(item, amount));
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
            //Tilføj varen
            if (items.Count() == 1)
            {
                items.ElementAt(0).Amount -= amount;
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

        //public  SortedForPrice<>() where T : IEnumerable<T>

        public List<InventoryEntry> SortedForPrice(Range<decimal> range) 
        {
            List<InventoryEntry> SortedList = new List<InventoryEntry>();
            IEnumerable<InventoryEntry> items = SortedList.Where(p => range.Contains(p.Item.Price));
            return SortedList;
        }
    }
}
