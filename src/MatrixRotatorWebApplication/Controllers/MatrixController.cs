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

        [HttpPost]
        public IActionResult Index([ModelBinder(BinderType = typeof(MatrixBinder<int?>))] Matrix<int?> matrix)
        {
            return View(matrix);
        }

    }
}
