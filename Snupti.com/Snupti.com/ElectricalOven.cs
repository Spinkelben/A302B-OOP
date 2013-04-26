using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{

    class ElectricalOven : KitchenItem, IEnergyRating
    {
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
                if (value < 0)
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
        /// Ikke færdig - ændres muligvis
        /// </summary>
        /// <returns></returns>
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
            //Jeg, Søren, har added denne else blok for at fjerne en fejl sådan at jeg kan koncentrerer 
            // om den kode jeg arbejder på.
            else
            {
                return EnergyRating.G;
            }
        }
        public override KitchenItem.SmileySystem Smiley
        {
            get { throw new NotImplementedException(); }
        }
        public double RelativePowerConsumption()
        {
            throw new NotImplementedException();
        }
    }

    
}
