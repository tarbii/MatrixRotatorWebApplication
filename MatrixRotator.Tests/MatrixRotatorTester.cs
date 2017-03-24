using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixRotator.Tests
{
    [TestClass]
    public class MatrixRotatorTester
    {
        private static bool CompareArrays<T>(T[,] array1, T[,] array2)
        {
            return Enumerable.Range(0, array1.Rank)
                .All(dimension => array1.GetLength(dimension) == array2.GetLength(dimension))
                   && array1.Cast<T>().SequenceEqual(array2.Cast<T>());
        }


        [TestMethod]
        public void TestOnSize2()
        {
            var matrix = new[,]
            {
                {1, 2},
                {3, 4}
            };
            var rotatedMatrix = new[,]
            {
                {3, 1},
                {4, 2}
            };
            matrix.RotateMatrix();
            Assert.IsTrue(CompareArrays(rotatedMatrix, matrix));
        }

        [TestMethod]
        public void TestOnSize7()
        {
            var matrix = new[,]
            {
                {1, 2, 3, 4, 5, 6, 7},
                {8, 9, 3, 2, 7, 2, 6},
                {4, 6, 9, 8, 7, 2, 1},
                {7, 1, 3, 5, 8, 9, 3},
                {2, 3, 4, 6, 7, 8, 2},
                {5, 1, 2, 3, 4, 7, 9},
                {4, 1, 2, 8, 7, 6, 1}
            };
            var rotatedMatrix = new[,]
            {
                {4, 5, 2, 7, 4, 8, 1},
                {1, 1, 3, 1, 6, 9, 2},
                {2, 2, 4, 3, 9, 3, 3},
                {8, 3, 6, 5, 8, 2, 4},
                {7, 4, 7, 8, 7, 7, 5},
                {6, 7, 8, 9, 2, 2, 6},
                {1, 9, 2, 3, 1, 6, 7}
            };
            matrix.RotateMatrix();
            Assert.IsTrue(CompareArrays(rotatedMatrix, matrix));
        }

        [TestMethod]
        public void TestOnSize8()
        {
            var matrix = new[,]
            {
                {1, 2, 3, 4, 5, 6, 7, 8},
                {8, 9, 3, 2, 7, 2, 6, 5},
                {4, 6, 9, 8, 7, 2, 1, 2},
                {7, 1, 3, 5, 8, 9, 3, 6},
                {2, 3, 4, 6, 7, 8, 2, 4},
                {5, 1, 2, 3, 4, 7, 9, 6},
                {4, 1, 2, 8, 7, 6, 1, 8},
                {5, 8, 6, 3, 2, 7, 1, 6},
            };
            var rotatedMatrix = new[,]
            {
                {5, 4, 5, 2, 7, 4, 8, 1},
                {8, 1, 1, 3, 1, 6, 9, 2},
                {6, 2, 2, 4, 3, 9, 3, 3},
                {3, 8, 3, 6, 5, 8, 2, 4},
                {2, 7, 4, 7, 8, 7, 7, 5},
                {7, 6, 7, 8, 9, 2, 2, 6},
                {1, 1, 9, 2, 3, 1, 6, 7},
                {6, 8, 6, 4, 6, 2, 5, 8},
            };
            matrix.RotateMatrix();
            Assert.IsTrue(CompareArrays(rotatedMatrix, matrix));
        }
    }
}
