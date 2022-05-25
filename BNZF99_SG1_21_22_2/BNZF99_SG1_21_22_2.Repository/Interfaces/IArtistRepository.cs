using BNZF99_SG1_21_22_2.Models.Entities;

namespace BNZF99_SG1_21_22_2.Repository.Interfaces
{
    public interface IArtistRepository : IRepositoryBase<Artist, int>
    {
        void Delete(Artist entity);
    }
}
