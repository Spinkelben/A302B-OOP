using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class Program
    {
        static void Main(string[] args)
        {
            Dimensions size = new Dimensions();
            Console.WriteLine(size);
            Dryer hej = new Dryer();
            
            hej.PowerConsumption = 1;
            hej.Size = size;
            int a = 5;
            Console.WriteLine(a.IsBetween(0,4
));

            Console.WriteLine(hej.Size.Width);

            Console.ReadLine();
        }
    }
}
