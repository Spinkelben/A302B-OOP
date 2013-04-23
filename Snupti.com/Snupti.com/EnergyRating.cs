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
        static List<double> CondenserDryerThreshold = new List<double>() { 0.55, 0.64, 0.73, 0.82, 0.91, 1.00 };

        static public EnergyRating GetCondenserDryerRating(double relativePowerConsumption) 
        {
            EnergyRating result = EnergyRating.G;
            foreach (double c in CondenserDryerThreshold) 
            {
                if (relativePowerConsumption <= c)
                {
                    return result = (EnergyRating)CondenserDryerThreshold.IndexOf(c);
                }
            }
            return result;
        }
    }
}
