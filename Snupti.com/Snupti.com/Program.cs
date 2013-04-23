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
            
            CondenserDryer Hej = new CondenserDryer();
            Hej.PowerConsumption = 5.0;
            Hej.Capacity = 5;
            Console.WriteLine(Hej.GetEnergyRating());
            
            int a = 5;
            Console.WriteLine(a.IsBetween(0,4));


            Console.ReadLine();

        }
    }
}
