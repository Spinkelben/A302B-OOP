using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    interface IEnergyRating
    {
        double RelativePowerConsumption();
        EnergyRating GetEnergyRating();
    }

    enum EnergyRating { A, B, C, D, E, F, G };

    static class EnergyTables
    {
        static public EnergyRating GetCondenserDryerRating(double relativePowerConsumption) 
        {
            if (relativePowerConsumption <= 0.55) 
            {
                return EnergyRating.A;
            }
            if (relativePowerConsumption <= 0.64)
            {
                return EnergyRating.B;
            }
            if (relativePowerConsumption <= 0.73)
            {
                return EnergyRating.C;
            }
            if (relativePowerConsumption <= 0.82)
            {
                return EnergyRating.D;
            }
            if (relativePowerConsumption <= 0.91)
            {
                return EnergyRating.E;
            }
            if (relativePowerConsumption <= 1.00)
            {
                return EnergyRating.F;
            }
            return EnergyRating.G;

        }
    }
}
