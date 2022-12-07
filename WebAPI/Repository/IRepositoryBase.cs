namespace WebAPI.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity: class, new()
    {
        TEntity GetById(int Id);
        List<TEntity> GetList();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
