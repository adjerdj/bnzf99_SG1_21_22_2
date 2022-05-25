using BNZF99_SG1_21_22_2.Models.Enums;
using BNZF99_SG1_21_22_2.WpfClient.BL.Interfaces;
using BNZF99_SG1_21_22_2.WpfClient.Models;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using System;

namespace BNZF99_SG1_21_22_2.WpfClient.ViewModels
{
    public class ArtistEditorWindowVM : ViewModelBase
    {
        private ArtistModel currentArtist;

        public ArtistModel CurrentArtist
        {
            get { return currentArtist; }
            set { Set(ref currentArtist, value); }
        }

        internal bool ShowDialog()
        {
            throw new NotImplementedException();
        }

        public Instruments[] MusicalInstruments => (Instruments[])Enum.GetValues(typeof(Instruments));

        private bool editEnabled;

        public bool EditEnabled
        {
            get { return editEnabled; }
            set
            {
                Set(ref editEnabled, value);
                RaisePropertyChanged(nameof(CancelButtonVisibility));
            }
        }

        public System.Windows.Visibility CancelButtonVisibility => EditEnabled ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

        public ArtistEditorWindowVM(IArtistHandlerService artistHandlerService)
        {
            currentArtist = new ArtistModel();
        }

        public ArtistEditorWindowVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IArtistHandlerService>())
        {

        }

    }
}
