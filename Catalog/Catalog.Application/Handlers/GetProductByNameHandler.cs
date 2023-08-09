using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetProductByNameHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var productsList = await _repository.GetProductByName(request.Name);
            var productsResponseList = ProductMapper.Mapper.Map<List<ProductResponse>>(productsList);
            return productsResponseList;
        }
    }
}
