using BNZF99_SG1_21_22_2.WpfClient.BL.Interfaces;
using BNZF99_SG1_21_22_2.WpfClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNZF99_SG1_21_22_2.WpfClient
{
    class ArtistEditorViaWindowService : IArtistEditorService
    {
        public ArtistModel EditArtist(ArtistModel artist)
        {
            var window = new ArtistEditorWindow(artist);

            if (window.ShowDialog() == true)
            {
                return window.Artist;
            }

            return null;
        }
    }
}


