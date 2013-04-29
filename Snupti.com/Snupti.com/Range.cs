using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{   
    /// <summary>
    /// Generisk klasse til af afgøre om en værdi er inkluderet i en spænd.
    /// </summary>
    /// <typeparam name="T">Typen af variabel der skal sammenlignes.</typeparam>
    class Range<T> where T : IComparable
    {
        private T _minimum;
        private T _maximum;
        /// <summary>
        /// Nedre grænse.
        /// </summary>
        public T Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                _minimum = value;
            }
        }
        /// <summary>
        /// Øvre Grænse;
        /// </summary>
        public T Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
            }
        }
        /// <summary>
        /// Constructor der tager en minimuns of maksimumsværdi. 
        /// </summary>
        /// <param name="minimum">Nedre grænseværdi.</param>
        /// <param name="maximum">Øvre grænseværdi.</param>
        public Range(T minimum, T maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
        /// <summary>
        /// Metode til at beregne hvorvidt en givet værdi er inden for en given rækkevidde.
        /// </summary>
        /// <param name="value">Værdien der skal tjekkes.</param>
        /// <returns>Boolsk værdi, hvorvidt værdien er imellem grænseværdierne.</returns>
        public bool Contains(T value)
        {
            return this.Contains(value, Minimum, Maximum);
        }
        /// <summary>
        /// Metode til at beregne hvorvidt en givet værdi er inden for en given rækkevidde.
        /// </summary>
        /// <param name="value">Værdien der skal tjekkes.</param>
        /// <param name="Minimum">Nedre grænse.</param>
        /// <param name="Maximum">Øvre grænse.</param>
        /// <returns>Boolsk værdi, hvorvidt værdien er imellem grænseværdierne.</returns>
        public bool Contains(T value, T Minimum, T Maximum) 
        {
            return value.CompareTo(Minimum) >= 0 && value.CompareTo(Maximum) <= 0;
        }
    }
}
