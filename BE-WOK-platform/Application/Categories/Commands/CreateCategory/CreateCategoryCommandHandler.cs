using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category { Name= request.Name };

            var result = await _categoryRepository.Create(category, cancellationToken);

            return result;
        }
    }
}
