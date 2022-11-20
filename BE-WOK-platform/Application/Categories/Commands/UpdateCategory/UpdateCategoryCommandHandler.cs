using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.Id, cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(Category),
                    request.Id);

            category.Name = request.Name;

            return await _categoryRepository.Update(category, cancellationToken);
        }
    }
}
