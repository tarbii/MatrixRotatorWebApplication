using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixRotatorWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatrixRotatorWebApplication.Controllers
{
    public class MatrixController : Controller
    {

        public IActionResult Index()
        {
            const int size = 5;
            var matrix = new Matrix<int?>(size) { Elements = new int?[size, size] };
            return View(matrix);
        }

        public IActionResult ChangeSize(int size)
        {
            var matrix = new Matrix<int?>(size) { Elements = new int?[size, size] };
            return View("Index", matrix);
        }

        public IActionResult Rotate([ModelBinder(BinderType = typeof(MatrixBinder<int?>))] Matrix<int?> matrix)
        {
            var rotatedMatrix = new Matrix<int?>(matrix.Size) { Elements = matrix.Elements };
            //var rotatedMatrix = matrix.Rotate();
            ViewData["RotatedMatrix"] = rotatedMatrix;
            return View("Index", matrix);
        }

    }
}
