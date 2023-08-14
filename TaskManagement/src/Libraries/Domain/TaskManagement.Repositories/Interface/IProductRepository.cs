
using TaskManagement.Model;
using TaskManagement.Services.Model;
using TaskManagement.Shared.CommonRepository;

namespace TaskManagement.Repositories.Interface;

public interface IProductRepository : IRepository<Product,VmProduct,int>
{



}
