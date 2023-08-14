using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure;
using TaskManagement.Model;
using TaskManagement.Repositories.Interface;
using TaskManagement.Services.Model;
using TaskManagement.Shared.CommonRepository;

namespace TaskManagement.Repositories.Base;

public class ProductRepository : RepositoryBase<Product, VmProduct, int>, IProductRepository
{
    public ProductRepository(IMapper mapper, TaskManagementDbContext dbContext) : base(mapper, dbContext)
    {
    }
}

