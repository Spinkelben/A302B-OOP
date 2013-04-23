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
            
            CondenserDryer Hej = new CondenserDryer("Smiele",5000);
            Hej.PowerConsumption = 0.645;
            Hej.Capacity = 1;
           
            Console.WriteLine("Energi pr kg tøj {0}, Energi rating: {1}", Hej.GetEnergyRating(), Hej.RelativePowerConsumption());
            
            int a = 5;
            Console.WriteLine(a.IsBetween(0,4));


            Console.ReadLine();

        }
    }
}
