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
    public class GetProductByBrandHandler : IRequestHandler<GetProductsByBrandQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetProductByBrandHandler(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<IList<ProductResponse>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            var productsList = await _repository.GetProductByBrand(request.Brand);
            var productsResponseList = ProductMapper.Mapper.Map<IList<ProductResponse>>(productsList);
            return productsResponseList;
        }
    }
}
