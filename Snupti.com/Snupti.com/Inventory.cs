using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class Inventory
    {
        private List<Tuple<Item, int>> _stock = new List<Tuple<Item, int>>();

        public string GetStatus()
        {
            string result = "";
            foreach (Tuple<Item, int> i in _stock)
            {
                result += "Model: " + i.Item1.Name + " Antal: " + i.Item2 + "\n"; 
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
            var items = _stock.Where(s => s.Item1.Name == item.Name);
            if (items.Count() > 1)
            {
                throw new Exception("Mere end en type vare med det modelnavn");
            }
            //Tilføj varen
            if (items.Count() == 1)
            {
                int indexOfItem;
                Tuple<Item, int> temp;
                Item tempItem = items.ElementAt(0).Item1;
                int newAmount = items.ElementAt(0).Item2 + amount;
                temp = new Tuple<Item, int>(tempItem, newAmount);
                _stock.Add(temp);
                indexOfItem = _stock.IndexOf(items.ElementAt(0));
                _stock.RemoveAt(indexOfItem);
                
            }
            else
            {
                _stock.Add(new Tuple<Item,int>(item, amount));
            }
           
        }
    }
}
