using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using CsvHelper;
using MatrixRotator;
using MatrixRotatorWebApplication.Models;
using Microsoft.AspNetCore.Http;
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

        public IActionResult UploadMatrix(IFormFile file)
        {
            var elementsList = new List<string[]>();
            using (var textReader = new StreamReader(file.OpenReadStream()))
            {
                var csv = new CsvReader(textReader);
                csv.Configuration.HasHeaderRecord = false;
                while (csv.Read())
                {
                    elementsList.Add(csv.CurrentRecord);
                }
            }
            var size = elementsList.Count;
            var elements = new string[size, size];
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    elements[i, j] = elementsList[i][j];
                }
            }
            var matrix = new Matrix<string>(size) { Elements = elements };
            return View("Index", matrix);
        }

        public FileResult Download(
            [ModelBinder(BinderType = typeof(MatrixBinder<string>))] Matrix<string> rotatedMatrix)
        {
            using (var ms = new MemoryStream())
            {
                using (var tw = new StreamWriter(ms))
                {
                    using (var csvWrite = new CsvWriter(tw))
                    {
                        for (var i = 0; i < rotatedMatrix.Size; i++)
                        {
                            for (var j = 0; j < rotatedMatrix.Size; j++)
                            {
                                csvWrite.WriteField(rotatedMatrix.Elements[i, j]);
                            }
                            csvWrite.NextRecord();
                        }
                    }
                }
                var fileName = $"RotatedMatrix.csv";
                return File(ms.ToArray(), "application/octet-stream", fileName);
            }
        }

    }
}
