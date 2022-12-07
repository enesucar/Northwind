using Microsoft.EntityFrameworkCore;
using WebAPI.Repository;

namespace WebAPI.Data.EntityFramework
{
    public abstract class EfRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity> 
        where TEntity : class, new()
        where TContext : DbContext, new()
    {

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetList()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
