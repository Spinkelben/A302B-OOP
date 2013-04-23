using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class CondenserDryer : Dryer
    {
        public override EnergyRating GetEnergyRating()
        {
            return EnergyTables.GetCondenserDryerRating(RelativePowerConsumption());
        }
    }
}
