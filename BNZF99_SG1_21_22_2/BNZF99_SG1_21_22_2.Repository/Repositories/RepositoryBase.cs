using BNZF99_SG1_21_22_2.Repository.DbContexts;
using BNZF99_SG1_21_22_2.Repository.Interfaces;
using System.Linq;

namespace BNZF99_SG1_21_22_2.Repository.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        protected ArtistDbContext Context;

        protected RepositoryBase(ArtistDbContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> ReadAll()
        {
            return Context.Set<TEntity>();
        }

        public abstract TEntity Read(TKey id);

        public TEntity Create(TEntity entity)
        {
            var result = Context.Add(entity);
            Context.SaveChanges();
            return result.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var result = Context.Update(entity);
            Context.SaveChanges();
            return result.Entity;
        }

        public void Delete(TKey id)
        {
            Context.Remove(Read(id));
            Context.SaveChanges();
        }
    }
}
