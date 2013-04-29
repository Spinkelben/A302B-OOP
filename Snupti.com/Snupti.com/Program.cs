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
            //Instantier lagerlisten 
            Inventory AllGoods = Inventory.GetInstance();
            
            //Skaber varer
            
            VentedDryer Ventd1 = new VentedDryer("Smiele supertørrer 3000",5000,5.67,5,new Dimensions(2345,23443,332),76,120,true);
            VentedDryer Ventd2 = new VentedDryer("Siemens SilentDry", 4500, 6.7, 7, new Dimensions(1000, 1500, 1250), 50, 150, false);
            VentLessDryer VentL1 = new VentLessDryer("Dyson Instadry", 5500, 7.8, 5, new Dimensions(1250, 1250, 1250), 130, 5, true);
            VentLessDryer VentL2 = new VentLessDryer("Focus Hocus Pocus Dry", 4999, 3.2, 6, new Dimensions(1300, 1450, 1500), 78, 100, false);
            ExhaustHood ExHood1 = new ExhaustHood("Suck-O-Matic", 1200, "Frithængt", 610, false, 78);
            ExhaustHood ExHood2 = new ExhaustHood("NoFan-LowNoise", 1750, "Indbygget", 175, true, 25);
            ExhaustHood ExHood3 = new ExhaustHood("Hood4U", 3100, "Væghængt", 1450, true, 135);


            //Tilføjer varer til lagerlisten
            AllGoods.Add(Ventd1, 500);
            Console.WriteLine(AllGoods.GetStatus());
            AllGoods.Add(Ventd1, 200);
            Console.WriteLine(AllGoods.GetStatus());
            AllGoods.Add(Ventd2, 150);
            AllGoods.Add(VentL1, 350);
            AllGoods.Add(VentL2, 450);
            Console.WriteLine(AllGoods.GetStatus());
            AllGoods.AddExisting("Siemens SilentDry", 5);
            AllGoods.Remove("Dyson Instadry", 10);
            Console.WriteLine(AllGoods.GetStatus());

            Console.ReadLine();

        }
    }
}
