using BNZF99_SG1_21_22_2.Logic.Interfaces;
using BNZF99_SG1_21_22_2.Models.Entities;
using BNZF99_SG1_21_22_2.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BNZF99_SG1_21_22_2.Logic.Services
{
    public class ArtistLogic : IArtistLogic
    {
        IArtistRepository _artistRepository;

        public ArtistLogic(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public IList<Artist> ReadAll()
        {
            return _artistRepository.ReadAll().ToList();
        }

        public Artist Read(int id)
        {
            return _artistRepository.Read(id);
        }

        public Artist Create(Artist entity)
        {
            return _artistRepository.Create(entity);
        }

        public Artist Update(Artist entity)
        {
            return _artistRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _artistRepository.Delete(id);
        }
    }
}
