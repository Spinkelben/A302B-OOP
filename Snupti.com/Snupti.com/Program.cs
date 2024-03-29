﻿using System;
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
            //Linker Observeren
            StockLowEventListener SLEL = new StockLowEventListener(AllGoods);

            //Skaber varer
            
            VentedDryer Ventd1 = new VentedDryer("Smiele supertørrer 3000",5000m,5.67,5,new Dimensions(2345,23443,332),76,120,true);
            VentedDryer Ventd2 = new VentedDryer("Siemens SilentDry", 4500m, 6.7, 7, new Dimensions(1000, 1500, 1250), 50, 150, false);
            VentLessDryer VentL1 = new VentLessDryer("Dyson Instadry", 5500m, 7.8, 5, new Dimensions(1250, 1250, 1250), 130, 5, true);
            VentLessDryer VentL2 = new VentLessDryer("Focus Hocus Pocus Dry", 4999m, 3.2, 6, new Dimensions(1300, 1450, 1500), 78, 100, false);
            ExhaustHood ExHood1 = new ExhaustHood("Suck-O-Matic", 1200m, "Frithængt", 610, false, 78);
            ExhaustHood ExHood2 = new ExhaustHood("NoFan-LowNoise", 1750m, "Indbygget", 175, true, 25);
            ExhaustHood ExHood3 = new ExhaustHood("Hood4U", 3100m, "Væghængt", 1450, true, 135);
            MicrowaveOven Micro1 = new MicrowaveOven("Radioactive Chef 5.0", 4500m, 1200, new Dimensions(500, 1000, 500), 25, false, false);
            MicrowaveOven Micro2 = new MicrowaveOven("RayPower CookBox", 4000m, 1100, new Dimensions(650, 1250, 500), 30, true, true);
            MicrowaveOven Micro3 = new MicrowaveOven("Old Radar Supplies", 3500m, 1500, new Dimensions(600, 1200, 600), 28, false, true);
            MicrowaveOven Micro4 = new MicrowaveOven("Micropower", 3999.95m, 1200, new Dimensions(600, 1200, 600), 40, true, false);
            BuildInOven Oven1 = new BuildInOven("Heat Box", 5999.95m, 2000, new Dimensions(1200, 1500, 1800), 50, false, new string[] { "Bradepande", "Grillhandsker" });
            BuildInOven Oven2 = new BuildInOven("Hunk of steel", 4999.95m, 1200, new Dimensions(1250, 1450, 1950), 200, true, new List<string>() { "Stegetermometer", "1/2 gris", "1 års forbrug af ovnrens" });

            Console.WriteLine("Test af ToString metoder på Varer");
            Console.WriteLine(ExHood1.ToString());
            Console.WriteLine(ExHood2.ToString());
            Console.WriteLine(ExHood3.ToString());
            Console.WriteLine(Micro4.ToString());
            Console.WriteLine(Ventd1.ToString());
            Console.WriteLine(VentL1.ToString());
            Console.WriteLine(Oven2.ToString());

            //Tilføjer varer til lagerlisten
            Console.WriteLine("\nTest af tilføjelse og fjernelse af varer fra lagerlisten inklusive event triggering");
            AllGoods.Add(Micro1, 20, 5);
            AllGoods.Add(Micro2, 50, 8);
            AllGoods.Add(Micro3, 100, 10);
            AllGoods.Add(Micro4, 10, 1);
            AllGoods.Add(Oven1, 25, 5);
            AllGoods.Add(Oven2, 35, 5);
            AllGoods.Add(Ventd1, 500);
            Console.WriteLine(AllGoods.GetStatus());
            AllGoods.Add(Ventd1, 200);
            AllGoods.Remove(Micro2, 42);
            AllGoods.Remove(Micro1, 16);
            AllGoods.Remove(Oven2, 33);
            Console.WriteLine(AllGoods.GetStatus());
            AllGoods.Add(Ventd2, 150);
            AllGoods.Add(VentL1, 350);
            AllGoods.Add(VentL2, 450);
            Console.WriteLine(AllGoods.GetStatus());
            AllGoods.AddExisting("Siemens SilentDry", 5);
            AllGoods.Remove("Dyson Instadry", 10);
            Console.WriteLine(AllGoods.GetStatus());
            AllGoods.Remove(Ventd1, 700);
            Console.WriteLine(AllGoods.GetStatus());
            AllGoods.RemoveFromDatabase(Ventd1);
            Console.WriteLine(AllGoods.GetStatus());

            //Find varer hvis navn matcher streng
            Console.WriteLine("\nFinder varer hvis navn mather en tekststreng: Cook\n");
            List<InventoryEntry> result = AllGoods.SearchForName("Cook");
            foreach (InventoryEntry i in result)
            {
                Console.WriteLine(i.Item.ToString());
            }

            //Find alle varer mellem en minimum og maksimum pris
            Console.WriteLine("\nFinder varer som ligger i pris intervallet 4000-4500 kr.\n");
            Range<Decimal> prisInterval = new Range<decimal>(4000, 4500);
            result = AllGoods.SearchForPrice(prisInterval);
            foreach (InventoryEntry i in result)
            {
                Console.WriteLine(i.Item.ToString());
            }

            //Find alle tørretumblere med et angivet energimærke
            Console.WriteLine("\nFinder tørretumblere i energiklasse G\n");
            result = AllGoods.SearchForEnergyRating(EnergyRating.G);
            foreach (InventoryEntry i in result)
            {
                Console.WriteLine(i.Item.ToString());
            }

            //Find alle varer der har en bestemt smiley
            Console.WriteLine("\nFinder alle varer med en glad smiley");
            result = AllGoods.SearchForSmiley(KitchenItem.SmileySystem.Glad);
            foreach (InventoryEntry i in result)
            {
                Console.WriteLine(i.Item.ToString());
            }

            //Sorter Listen efter pris
            AllGoods.SortInventoryByPrice();
            //Iterer fra lav til høj
            Console.WriteLine("\nTest af iterering fra lav til høj pris");
            foreach (InventoryEntry IE in AllGoods.LowToHigh)
            {
                Console.WriteLine("Vare navn:" + IE.Item.Name + " Pris: " + IE.Item.Price);
            }
            Console.WriteLine("\nTest af iterering fra høj til lav pris");
            foreach (InventoryEntry IE in AllGoods.HighToLow)
            {
                Console.WriteLine("Vare navn:" + IE.Item.Name + " Pris: " + IE.Item.Price);
            }
            
            Console.ReadLine();

            //Afmelder observeren
            SLEL.Detach();
        }
    }
}
