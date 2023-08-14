using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repositories.Base;
using TaskManagement.Repositories.Interface;
using TaskManagement.Services.Model;

namespace TaskManagement.Core.Product.Command;

public record UpdateProduct (int Id, VmProduct VmProduct) :IRequest<VmProduct>;
public class UpdateProductHandler : IRequestHandler<UpdateProduct, VmProduct>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public UpdateProductHandler(IProductRepository productRepository,
IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task <VmProduct>Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Model.Product>(request.VmProduct);
        return await _productRepository.Update(request.Id, data);
    }
}