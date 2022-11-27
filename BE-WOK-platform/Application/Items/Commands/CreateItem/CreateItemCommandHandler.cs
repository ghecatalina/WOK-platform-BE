using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Item>
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateItemCommandHandler(
            IItemRepository itemRepository, 
            ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Item> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.CategoryId, cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(Category),
                    request.CategoryId);

            var item = new Item
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Ingredients = request.Ingredients,
                Description = request.Description,
                Photo = request.Photo,
                CategoryId = category.Id,
                Category = category,
            };

            return await _itemRepository.Create(item, cancellationToken);
        }
    }
}
