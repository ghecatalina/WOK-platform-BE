using Domain.Models;
using MediatR;

namespace Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
