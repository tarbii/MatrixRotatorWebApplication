using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MatrixRotatorWebApplication.Models
{
    public class MatrixBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            bindingContext.Result = ModelBindingResult.Success(new int?[,] { { 45 } });
            return Task.CompletedTask;
        }
    }
}
