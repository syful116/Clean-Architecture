using AutoMapper;
using MediatR;
using TaskManagement.Repositories.Base;
using TaskManagement.Repositories.Interface;
using TaskManagement.Services.Model;

namespace TaskManagement.Core.Product.Command;
public record CreateProduct(VmProduct Vmproduct) :IRequest<VmProduct>;
public class CrateProductHandler :IRequestHandler <CreateProduct, VmProduct >
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public CrateProductHandler(IProductRepository productRepository,
   IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<VmProduct> Handle(CreateProduct request,
    CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Model.Product>(request.Vmproduct);
        return await _productRepository.Add(data);
    }
}

