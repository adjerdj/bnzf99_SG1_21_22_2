using BNZF99_SG1_21_22_2.Models.Entities;
using System.Collections.Generic;

namespace BNZF99_SG1_21_22_2.Logic.Interfaces
{
    public interface IArtistLogic
    {
        IList<Artist> ReadAll();

        Artist Read(int id);

        Artist Create(Artist entity);

        Artist Update(Artist entity);

        void Delete(int id);
    }
}

