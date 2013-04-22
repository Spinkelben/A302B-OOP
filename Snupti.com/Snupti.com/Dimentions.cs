using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class Dimentions
    {
        /// <summary>
        /// Milimeter
        /// </summary>
        private int _width;
        /// <summary>
        /// Milimeter
        /// </summary>
        private int _height;
        /// <summary>
        /// Milimeter
        /// </summary>
        private int _length;

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("int width", "Skal være større end nul"); 
                }
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value > 0)
                {
                    _height = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("int height", "Skal være større end nul");
                }
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value > 0)
                {
                    _length = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("int lenght", "Skal være større end nul");
                }
            }
        }
        public Dimentions() 
            : this(1 ,1 ,1)
        {
            /*Empty*/
        }

        public Dimentions(int length)
            : this(length, 1, 1)
        {
            /*Empty*/
        }

        public Dimentions(int length, int width)
            : this(length, width, 1)
        {
            /*Empty*/
        }

        public Dimentions(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height; 
        }
        
    }
}
