using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixRotator
{
    public static class MatrixRotator
    {
        public static void RotateMatrix<T>(this T[,] matrix)
        {
            var n = matrix.GetLength(0);
            for (var i = 0; i < n / 2; i++)
            {
                for (var j = i; j < n - i - 1; j++)
                {
                    var a = matrix[j, n - i - 1];
                    matrix[j, n - i - 1] = matrix[i, j];
                    matrix[i, j] = matrix[n - j - 1, i];
                    matrix[n - j - 1, i] = matrix[n - i - 1, n - j - 1];
                    matrix[n - i - 1, n - j - 1] = a;
                }
            }
        }
    }
}
