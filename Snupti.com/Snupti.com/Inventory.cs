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

        public void Add(Item item, int amount)
        {
            //Tjek om varen allerede findes i listen
            var items = _stock.Where(s => s.Item1.Name == item.Name);
            if (items.Count() > 1)
            {
                Console.WriteLine("WHAT!");
            }
            //Tilføj varen
        }
    }
}
