using BNZF99_SG1_21_22_2.WpfClient.Models;
using System.Collections.Generic;

namespace BNZF99_SG1_21_22_2.WpfClient.BL.Interfaces
{
    public interface IArtistHandlerService
    {
        void AddArtist(IList<ArtistModel> collection);
        void ModifyArtist(IList<ArtistModel> collection, ArtistModel artist);
        void DeleteArtist(IList<ArtistModel> collection, ArtistModel artist);
        void ViewArtist(ArtistModel artist);

        IList<ArtistModel> GetAll();
    }
}
