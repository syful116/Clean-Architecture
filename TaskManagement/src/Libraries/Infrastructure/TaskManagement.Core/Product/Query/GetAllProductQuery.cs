using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TaskManagement.Repositories.Interface;
using TaskManagement.Services.Model;

namespace TaskManagement.Core.Product.Query;

public record GetAllProductQuery() :IRequest<IEnumerable<VmProduct>>;

public class GetAllProductQueryHandler :IRequestHandler<GetAllProductQuery, IEnumerable<VmProduct>>
{
    private readonly IProductRepository _ProductRepository;

    public GetAllProductQueryHandler(IProductRepository ProductRepository, IMapper mapper)
    {
        _ProductRepository = ProductRepository;
    }


    public async Task<IEnumerable<VmProduct>>Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _ProductRepository.GetList();
        return result;
    }
}
