using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snupti.com
{
    class Dimensions
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
        /// <summary>
        /// Bredde i milimeter.
        /// </summary>
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
        /// <summary>
        /// Højde i milimeter.
        /// </summary>
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
        /// <summary>
        /// Længde i milimeter.
        /// </summary>
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
        /// <summary>
        /// Skaber ny instans af størrelses klassen med højde, længde og bredde på 1 mm.
        /// </summary>
        public Dimensions() 
            : this(1 ,1 ,1)
        {
            /*Empty*/
        }
        /// <summary>
        /// Ny instans af størrelse, med højde og bredde på 1 mm.
        /// </summary>
        /// <param name="length">Længden i mm.</param>
        public Dimensions(int length)
            : this(length, 1, 1)
        {
            /*Empty*/
        }
        /// <summary>
        /// Ny instans af størrelse, med højden 1 mm.
        /// </summary>
        /// <param name="length">Længden i mm.</param>
        /// <param name="width">Bredden i mm.</param>
        public Dimensions(int length, int width)
            : this(length, width, 1)
        {
            /*Empty*/
        }
        /// <summary>
        /// Ny instans af størrelsen.
        /// </summary>
        /// <param name="length">Længde i mm.</param>
        /// <param name="width">Bredde i mm.</param>
        /// <param name="height">Højde i mm.</param>
        public Dimensions(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height; 
        }
        
    }
}
