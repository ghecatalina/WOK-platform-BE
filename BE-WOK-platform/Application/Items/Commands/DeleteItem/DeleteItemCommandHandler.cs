using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Unit>
    {
        private readonly IItemRepository _itemRepository;

        public DeleteItemCommandHandler(
            IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.Get(request.CategoryId, request.Id, cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(Item),
                    (nameof(Item.CategoryId), request.CategoryId),
                    (nameof(Item.Id), request.Id));

            await _itemRepository.Delete(item, cancellationToken);

            return Unit.Value;
        }
    }
}
