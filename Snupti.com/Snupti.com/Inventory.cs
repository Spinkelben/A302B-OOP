using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class Inventory
    {
        private List<InventoryEntry> _stock = new List<InventoryEntry>();

        public string GetStatus()
        {
            string result = "";
            foreach (InventoryEntry i in _stock)
            {
                result += "Model: " + i.Item.Name + " Antal: " + i.Amount + "\n"; 
            }
            return result;
        }

        public void Add(Item item)
        {
            this.Add(item, 1);
        }
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
                throw new ArgumentException("string", "Der findes ikke en vare med det navn");
            }
           
        }
        public void Remove(Item item, int amount)
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
                items.ElementAt(0).Amount -= amount;
            }
            else
            {
                throw new ArgumentException("item", "Varen findes ikke i systemet");
            }
        }
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
    }
}
