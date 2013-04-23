using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    /// <summary>
    /// Interface til implementering af Energy rating funktionaliteten.
    /// </summary>
    interface IEnergyRating
    {
        /// <summary>
        /// Metode der beregner energiforbruget relativt til den enkelte maskines størrelse.
        /// </summary>
        /// <returns>Double, det relative energiforbrug</returns>
        double RelativePowerConsumption();
        /// <summary>
        /// Metode der returnerer Energiklassen.
        /// </summary>
        /// <returns>EnergyRating. Energiklassen</returns>
        EnergyRating GetEnergyRating();

        
    }
    /// <summary>
    /// Enum med energiklasserne: Bogstaverne A-G.
    /// </summary>
    enum EnergyRating { A, B, C, D, E, F, G };

   
}
