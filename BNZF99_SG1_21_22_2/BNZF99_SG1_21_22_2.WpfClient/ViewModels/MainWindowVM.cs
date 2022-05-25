using BNZF99_SG1_21_22_2.WpfClient.BL.Interfaces;
using BNZF99_SG1_21_22_2.WpfClient.Models;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BNZF99_SG1_21_22_2.WpfClient.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private ArtistModel currentArtist;

        public ArtistModel CurrentArtist
        {
            get { return currentArtist; }
            set { Set(ref currentArtist, value); }
        }

        public ObservableCollection<ArtistModel> Artists { get; private set; }

        public ICommand AddCommand { get; private set; }
        public ICommand ModifyCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ViewCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }

        readonly IArtistHandlerService artistHandlerService;

        public MainWindowVM(IArtistHandlerService artistHandlerService)
        {
            this.artistHandlerService = artistHandlerService;
            Artists = new ObservableCollection<ArtistModel>();

            LoadCommand = new RelayCommand(() =>
            {
                var artists = this.artistHandlerService.GetAll();
                Artists.Clear();

                foreach (var artist in artists)
                {
                    Artists.Add(artist);
                }
            });

            AddCommand = new RelayCommand(() => this.artistHandlerService.AddArtist(Artists));
            ModifyCommand = new RelayCommand(() => this.artistHandlerService.ModifyArtist(Artists, CurrentArtist));
            DeleteCommand = new RelayCommand(() => this.artistHandlerService.DeleteArtist(Artists, CurrentArtist));
            ViewCommand = new RelayCommand(() => this.artistHandlerService.ViewArtist(CurrentArtist));
        }

        public MainWindowVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IArtistHandlerService>())
        {
        }
    }
}
