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
            var size = 7;
            var elements = new int?[,]
            {
                {1, 2, 3, 4, 5, 6, 7},
                {8, 9, 3, 2, 7, 2, 6},
                {4, 6, 9, 8, 7, 2, 1},
                {7, 1, 3, 5, 8, 9, 3},
                {2, 3, 4, 6, 7, 8, 2},
                {5, 1, 2, 3, 4, 7, 9},
                {4, 1, 2, 8, 7, 6, 1}
            };
            var matrix = new Matrix<int?>(size) {Elements = elements};
            return View(matrix);
        }

        [HttpPost]
        public IActionResult Index([ModelBinder(BinderType = typeof(MatrixBinder<int?>))] Matrix<int?> matrix)
        {
            return View(matrix);
        }

    }
}
