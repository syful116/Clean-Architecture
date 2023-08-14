using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Shared.Extentions;

namespace TaskManagement.Shared.CommonRepository;


public abstract class RepositoryBase<TEntity, IModel, T> : IRepository<TEntity, IModel, T>
    where TEntity : class, IEntity<T>, new()
    where IModel : class, IVm<T>, new()
    where T :  IEquatable<T>, new()

{

    private readonly IMapper _mapper;
    private readonly DbContext _dbContext;
    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    public RepositoryBase(IMapper mapper, DbContext dbContext)

    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    public async Task<IModel> Add(TEntity entity)
    {
        DbSet.Add(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<IModel>(entity);
    }
    public async Task<IModel> Delete(T id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null)
        {
            throw new InvalidOperationException("Data not found");
        }
        DbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<IModel>(entity);
    }
    public async Task<IModel> GetById(T id)
    {
        var Data = await DbSet.FindAsync(id);
        return _mapper.Map<IModel>(Data);
    }
    public async Task<IModel> Update(T id, TEntity entity)
    {
        var temp = await DbSet.FindAsync(id);
        if (temp is not null)
        {
            entity.Copy(temp);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<IModel>(temp);
        }
        throw new ArgumentNullException();
    }
    public Task<IEnumerable<IModel>> GetList()
    {
        var data = DbSet.ToList();
        var models = _mapper.Map<IEnumerable<IModel>>(data);
            return Task.FromResult(models);
    }

    public async Task<IModel> GetbyId(T Id)
    {
       var data= await DbSet.FindAsync(Id); 
        return _mapper.Map<IModel>(data);
    }
}
