using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Categories
{
    public class CategoryPostPutModel
    {
        [Required(ErrorMessage = "Category Name is required")]
        public string Name { get; set; }
    }
}
