using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, Item>
    {
        private readonly IItemRepository _itemRepository;

        public GetItemByIdQueryHandler(
            IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.Get(request.CategoryId, request.Id, cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(Item),
                    (nameof(Item.CategoryId), request.CategoryId),
                    (nameof(Item.Id), request.Id));

            return item;
        }
    }
}
