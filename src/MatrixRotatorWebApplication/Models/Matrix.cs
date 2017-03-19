using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixRotatorWebApplication.Models
{
    public class Matrix<T>
    {
        public int Size { get; set; }

        public T[,] Elements { get; set; }

        public Matrix(int size)
        {
            Size = size;
        }
    }
}
