using BNZF99_SG1_21_22_2.WpfClient.Models;
using BNZF99_SG1_21_22_2.WpfClient.ViewModels;
using System.Windows;

namespace BNZF99_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for ArtistEditorWindow.xaml
    /// </summary>
    public partial class ArtistEditorWindow : Window
    {
        public ArtistModel Artist { get; set; }
        bool enableEdit;
        public ArtistEditorWindow(ArtistModel artist = null, bool enableEdit = true)
        {
            InitializeComponent();
            Artist = artist == null ? new ArtistModel() : new ArtistModel(artist);

            this.enableEdit = enableEdit;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = true;
            }
            else
            {
                Close();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = false;
            }
            else
            {
                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = (ArtistEditorWindowVM)Resources["VM"];
            vm.CurrentArtist = Artist;
            vm.EditEnabled = enableEdit;
        }
    }
}
