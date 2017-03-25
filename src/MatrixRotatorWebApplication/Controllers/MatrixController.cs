using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using CsvHelper;
using MatrixRotator;
using MatrixRotatorWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatrixRotatorWebApplication.Controllers
{
    public class MatrixController : Controller
    {

        public IActionResult Index()
        {
            const int size = 5;
            var matrix = new Matrix<string>(size) { Elements = new string[size, size] };
            return View(matrix);
        }

        public IActionResult ChangeSize(int size)
        {
            var matrix = new Matrix<string>(size) { Elements = new string[size, size] };
            return View("Index", matrix);
        }

        public IActionResult Rotate([ModelBinder(BinderType = typeof(MatrixBinder<string>))] Matrix<string> matrix)
        {
            var rotatedElements = new string[matrix.Size, matrix.Size];
            Array.Copy(matrix.Elements, rotatedElements, matrix.Elements.Length);
            rotatedElements.RotateMatrix();
            var rotatedMatrix = new Matrix<string>(matrix.Size) { Elements = rotatedElements };
            ViewData["RotatedMatrix"] = rotatedMatrix;
            return View("Index", matrix);
        }

    }
}
