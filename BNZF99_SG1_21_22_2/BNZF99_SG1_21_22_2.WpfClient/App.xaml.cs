using BNZF99_SG1_21_22_2.WpfClient.BL.Implementations;
using BNZF99_SG1_21_22_2.WpfClient.BL.Interfaces;
using BNZF99_SG1_21_22_2.WpfClient.Infrastructure;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BNZF99_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIocAsServiceLocator.Instance);

            SimpleIocAsServiceLocator.Instance.Register<IArtistEditorService, ArtistEditorViaWindowService>();
            SimpleIocAsServiceLocator.Instance.Register<IArtistDisplayService, ArtistDisplayService>();
            SimpleIocAsServiceLocator.Instance.Register<IArtistHandlerService, ArtistHandlerService>();
            SimpleIocAsServiceLocator.Instance.Register(() => Messenger.Default);
        }
    }
}
