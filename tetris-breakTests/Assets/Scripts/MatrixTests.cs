using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        // [1, 2    =>   [3, 1]
        //  3, 4]         4, 2]
        public void RotateClockwiseTest()
        {
            var matrix = new Matrix<int>(2, 2);
            matrix.Set(0, 0, 1);
            matrix.Set(1, 0, 2);
            matrix.Set(0, 1, 3);
            matrix.Set(1, 1, 4);

            matrix.RotateClockwise();
            Assert.AreEqual(matrix[0, 0], 3);
            Assert.AreEqual(matrix[1, 0], 1);
            Assert.AreEqual(matrix[0, 1], 4);
            Assert.AreEqual(matrix[1, 1], 2);
        }

        [TestMethod()]
        //[1, 2    =>   [2, 4]
        // 3, 4]         1, 3]
        public void RotateCounterClockwiseTest()
        {
            var matrix = new Matrix<int>(2, 2);
            matrix.Set(0, 0, 1);
            matrix.Set(1, 0, 2);
            matrix.Set(0, 1, 3);
            matrix.Set(1, 1, 4);

            matrix.RotateCounterClockwise();
            Assert.AreEqual(matrix[0, 0], 2);
            Assert.AreEqual(matrix[1, 0], 4);
            Assert.AreEqual(matrix[0, 1], 1);
            Assert.AreEqual(matrix[1, 1], 3);
        }

        [TestMethod()]
        //[1, 2, 3, 4    =>   [5, 1
        // 5, 6, 7, 8]         6, 2
        //                     7, 3
        //                     8, 4]
        public void RotateUnevenTest()
        {
            var matrix = new Matrix<int>(4, 2);
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    matrix.Set(x, y, y * 4 + x + 1);
                }
            }

            // Check some
            Assert.AreEqual(matrix[3, 0], 4);
            Assert.AreEqual(matrix[2, 1], 7);
            Assert.AreEqual(matrix[0, 1], 5);

            // Rotate
            matrix.RotateClockwise();
            Assert.AreEqual(matrix.SizeX, 2);
            Assert.AreEqual(matrix.SizeY, 4);

            // Check all
            int num = 1;
            for (int x = 1; x >= 0; x--)
            {
                for (int y = 0; y < 4; y++)
                {
                    Assert.AreEqual(matrix[x, y], num);
                    num++;
                }
            }

            // Rotate back
            matrix.RotateCounterClockwise();
            Assert.AreEqual(matrix.SizeX, 4);
            Assert.AreEqual(matrix.SizeY, 2);

            // Check all
            num = 1;
            for(int y = 0; y < 2; y++)
            {
                for(int x = 0; x < 4; x++)
                {
                    Assert.AreEqual(matrix[x, y], num);
                    num++;
                }
            }
        }
    }
}