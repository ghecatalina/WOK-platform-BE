using MediatR;

namespace Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
