﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{

    abstract class ElectricalOven : KitchenItem, IEnergyRating
    {
       /* public ElectricalOven(string name, int price, double powerConsumption, )
            : base(name, price)
        {
            _powerConsumption = powerConsumption; 
        } */
        

        /// <summary>
        /// Strømforbrug i kWh
        /// </summary>
        private double _powerConsumption;

        /// <summary>
        /// Dimensioner i mm. - lændge, bredde & højde.
        /// </summary>
        private Dimensions _size;
        
        /// <summary>
        /// Volumen i liter
        /// </summary>
        private int _volume;

        /// <summary>
        /// Strømforbrug i kWh
        /// </summary>
        public double PowerConsumption
        {
            get
            {
                return _powerConsumption;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("PowerConsumption", "Kan ikke være mindre end 0");
                }
                else
                {
                    _powerConsumption = value;
                }
            }
        }

        /// <summary>
        /// Dimensioner i mm. - lændge, bredde & højde.
        /// </summary>
        public Dimensions Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
        
        /// <summary>
        /// Volumen i liter
        /// </summary>
        public int Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (value > 0)
                {
                    _volume = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("Volume", "Volume kan ikke være mindre end 0");
                }
            }
        }
        /// <summary>
        /// Constructor der ikke tildeler nogen default værdier.
        /// </summary>
        /// <param name="name">Modelnavn.</param>
        /// <param name="price">Pris i kr.</param>
        /// <param name="powerConsumption">Strømforbrug i kWh.</param>
        /// <param name="size">Dimentioner i mm, længde, bredde højde</param>
        /// <param name="volume">Ovnens volumen i liter.</param>
        public ElectricalOven(string name, decimal price, double powerConsumption, Dimensions size, int volume)
            : base(name, price)
        {
            PowerConsumption = powerConsumption;
            Size = size;
            Volume = volume;
        }

        /// <summary>
        /// Udregning af energiklasse
        /// </summary>
        /// <returns>EnergyRating</returns>
        public EnergyRating GetEnergyRating()
        {
            if (PowerConsumption < 0.6)
            {
                if (Volume < 35)
                {
                    return EnergyRating.A;
                }
                else if (Volume < 65)
                {
                    return EnergyRating.A;
                }
                else
                {
                    return EnergyRating.A;
                }
            }
            else if (PowerConsumption < 0.8)
            {
                if (Volume < 35)
                {
                    return EnergyRating.B;
                }
                else if (Volume < 65)
                {
                    return EnergyRating.A;
                }
                else
                {
                    return EnergyRating.A;
                }
            }
            else if (PowerConsumption < 1.0)
            {
                if (Volume < 35)
                {
                    return EnergyRating.C;
                }
                else if (Volume < 65)
                {
                    return EnergyRating.B;
                }
                else
                {
                    return EnergyRating.A;
                }
            }
            else if (PowerConsumption < 1.2)
            {
                if (Volume < 35)
                {
                    return EnergyRating.D;
                }
                else if (Volume < 65)
                {
                    return EnergyRating.C;
                }
                else
                {
                    return EnergyRating.B;
                }
            }
            else if (PowerConsumption < 1.4)
            {
                if (Volume < 35)
                {
                    return EnergyRating.E;
                }
                else if (Volume < 65)
                {
                    return EnergyRating.D;
                }
                else
                {
                    return EnergyRating.C;
                }
            }
            else if (PowerConsumption < 1.6)
            {
                if (Volume < 35)
                {
                    return EnergyRating.F;
                }
                else if (Volume < 65)
                {
                    return EnergyRating.E;
                }
                else
                {
                    return EnergyRating.D;
                }
            }
            else if (PowerConsumption < 1.8)
            {
                if (Volume < 35)
                {
                    return EnergyRating.G;
                }
                else if (Volume < 65)
                {
                    return EnergyRating.F;
                }
                else
                {
                    return EnergyRating.E;
                }
            }
            else if (PowerConsumption < 2.0)
            {
                if (Volume < 35)
                {
                    return EnergyRating.G;
                }
                else if (Volume < 65)
                {
                    return EnergyRating.G;
                }
                else
                {
                    return EnergyRating.F;
                }
            }
            else
            {
                return EnergyRating.G;
            }
        }

        /// <summary>
        /// Udprinting af information om modellerne
        /// </summary>
        /// <returns>Information om modellen i strengformat. Et felt pr. linje.</returns>
        public override string ToString()
        {
            string result;
            string itemString = base.ToString();
            result = itemString;
            result += "Strømforbrug: " + PowerConsumption + " kWh\n";
            result += "Volumen: " + Volume + " L\n";
            result += "Dimentioner, i mm, B: " + Size.Width + " L: " + Size.Length + " H: " + Size.Height + "\n";
           
            return result;
        }
    }

    
}
