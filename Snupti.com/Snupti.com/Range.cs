using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    static class Range
    {
        private decimal _minimum;
        private decimal _maximum;

        public decimal Minimum
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

        public decimal Maximum
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
       

        public static bool IsBetween<T>(this T value, T minimum, T maximum) where T : IComparable
        {
            return value.CompareTo(minimum) >= 0 && value.CompareTo(maximum) <= 0;
        }
    }
}
