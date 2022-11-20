using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Extensions
{
    public static class ModelStateExtensions
    {
        public static string Errors(this ModelStateDictionary ModelState)
        {
            return string.Join(",", ModelState.Where(x => x.Value != null).SelectMany(x => x.Value!.Errors.Select(y => y.ErrorMessage)));
        }
    }
}
