using Domain.Models;
using MediatR;

namespace Application.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
