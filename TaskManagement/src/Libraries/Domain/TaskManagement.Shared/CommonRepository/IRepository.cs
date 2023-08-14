namespace TaskManagement.Shared.CommonRepository;

public interface IRepository <TEntity, IModel,T>
    where TEntity: class, IEntity<T>,new()
    where IModel : class,IVm<T>,new()
    where T :  IEquatable<T>

{
    public Task<IModel> GetbyId(T Id);

    public Task<IEnumerable<IModel>> GetList();
   
    public Task<IModel> Delete(T Id);

    public Task <IModel> Update(T Id ,TEntity entity);
    public Task<IModel> Add(TEntity entity);
}
