using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Items.Queries.GetItemsByCategory
{
    public class GetItemsByCategoryQueryHandler : IRequestHandler<GetItemsByCategoryQuery, IEnumerable<Item>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetItemsByCategoryQueryHandler(
            IItemRepository itemRepository, 
            ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Item>> Handle(GetItemsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.CategoryId, cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(Category),
                    request.CategoryId);

            return await _itemRepository.GetAll(request.CategoryId, cancellationToken);
        }
    }
}
