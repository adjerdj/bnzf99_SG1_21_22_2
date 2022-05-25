using BNZF99_SG1_21_22_2.Models.Entities;
using BNZF99_SG1_21_22_2.Repository.DbContexts;
using BNZF99_SG1_21_22_2.Repository.Interfaces;
using System.Linq;

namespace BNZF99_SG1_21_22_2.Repository.Repositories
{
    public class ArtistRepository : RepositoryBase<Artist, int>, IArtistRepository
    {
        public ArtistRepository(ArtistDbContext context) : base(context)
        {
        }

        public void Delete(Artist entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public override Artist Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
