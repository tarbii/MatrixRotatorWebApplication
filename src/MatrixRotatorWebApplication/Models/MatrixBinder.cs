using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MatrixRotatorWebApplication.Models
{
    public class MatrixBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            int size;
            if (!int.TryParse(bindingContext.ValueProvider.GetValue("Size").FirstValue, out size))
                return Task.CompletedTask;
            var elements = new T[size, size];
            for (var i = 0; i < size; i++)
            for (var j = 0; j < size; j++)
                elements[i, j] = BindingDeserializer.Deserialize<T>(
                    bindingContext.ValueProvider.GetValue($"Elements[{i}, {j}]").FirstValue);
            var matrix = new Matrix<T>(size) {Elements = elements};
            bindingContext.Result = ModelBindingResult.Success(matrix);
            return Task.CompletedTask;
        }
    }
}