using BNZF99_SG1_21_22_2.WpfClient.BL.Interfaces;
using BNZF99_SG1_21_22_2.WpfClient.Models;

namespace BNZF99_SG1_21_22_2.WpfClient
{
    public class ArtistDisplayService : IArtistDisplayService
    {
        public void Display(ArtistModel artist)
        {
            var window = new ArtistEditorWindow(artist, false);

            window.Show();
        }
    }
}
