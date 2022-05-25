using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;

namespace BNZF99_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<string[]>(this, "BlOperationResult",
                (msgs) => MessageBox.Show(String.Join(Environment.NewLine, msgs), "BL result", MessageBoxButton.OK, MessageBoxImage.Information));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}
