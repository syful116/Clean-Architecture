using MediatR;
using TaskManagement.Repositories.Base;
using TaskManagement.Repositories.Interface;
using TaskManagement.Services.Model;

namespace TaskManagement.Core.Product.Query;


public record GetProductById(int Id) : IRequest<VmProduct>;
public class GetProductByIdHandler : IRequestHandler<GetProductById, VmProduct>
{
    private readonly IProductRepository _productRepository;
    public GetProductByIdHandler(IProductRepository productRepository)

    {
        _productRepository = productRepository;
    }

    public async Task<VmProduct> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetbyId(request.Id);
    }
}