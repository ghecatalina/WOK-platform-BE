using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Item>
    {
        private readonly IItemRepository _itemRepository;

        public UpdateItemCommandHandler(
            IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.Get(request.CategoryId, request.Id, cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(Item),
                    (nameof(Item.CategoryId), request.CategoryId),
                    (nameof(Item.Id), request.Id));

            item.Name= request.Name;
            item.Description= request.Description;
            item.Quantity= request.Quantity;
            item.Photo = request.Photo;
            item.Ingredients= request.Ingredients;
            item.Price = request.Price;

            return await _itemRepository.Update(item, cancellationToken);
        }
    }
}
