namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix<T>
    {
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }

        /// <summary>
        /// All items
        /// </summary>
        private List<T> items;

        public Matrix(int x, int y)
        {
            if (x % 2 != y % 2)
            {
                throw new ArgumentException("X and Y must both be even, or both be odd");
            }

            this.SizeX = x;
            this.SizeY = y;

            this.items = new List<T>();
            for (int i = 0; i < x * y; i++)
            {
                this.items.Add(default(T));
            }
        }

        public T this[int x, int y]
        {
            get { return this.Get(x, y); }
            set { this.Set(x, y, value); }
        }

        public T Get(int x, int y)
        {
            if (x < 0 || y < 0 || x >= this.SizeX || y >= this.SizeY)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.items[y * this.SizeX + x];
        }

        public void Set(int x, int y, T value)
        {
            if (x < 0 || y < 0 || x >= this.SizeX || y >= this.SizeY)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.items[y * this.SizeX + x] = value;
        }

        //[1, 2    =>   [3, 1]
        // 3, 4]         4, 2]
        public void RotateClockwise()
        {
            var newItems = new List<T>();
            for (int x = 0; x < this.SizeX; x++)
            {
                for (int y = this.SizeY - 1; y >= 0; y--)
                {
                    newItems.Add(this[x, y]);
                }
            }
            this.items = newItems;
            this.SawpXY();
        }

        //[1, 2    =>   [2, 4]
        // 3, 4]         1, 3]
        public void RotateCounterClockwise()
        {
            var newItems = new List<T>();
            for (int x = this.SizeX - 1; x >= 0; x--)
            {
                for (int y = 0; y < this.SizeY; y++)
                {

                    newItems.Add(this[x, y]);
                }
            }
            this.items = newItems;
            this.SawpXY();
        }

        public override string ToString()
        {
            var str = "";
            for (int y = 0; y < this.SizeY; y++)
            {
                for (int x = 0; x < this.SizeX; x++)
                {
                    str += this[x, y].ToString();
                    str += ",";
                }
                str += '\n';
            }

            return str;
        }

        private void SawpXY()
        {
            var swapValue = this.SizeX;
            this.SizeX = this.SizeY;
            this.SizeY = swapValue;
        }
    }
}
