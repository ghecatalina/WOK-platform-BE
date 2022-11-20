using Domain.Models;
using MediatR;

namespace Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
