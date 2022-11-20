using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Exceptions.Extensions
{
    public static class ModelStateExtensions
    {
        public static string Errors(this ModelStateDictionary ModelState)
        {
            return String.Join(",", ModelState.Where(x => x.Value != null).SelectMany(x => x.Value!.Errors.Select(y => y.ErrorMessage)));
        }
    }
}
