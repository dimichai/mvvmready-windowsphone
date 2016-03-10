using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics;

namespace MVVMReadyWindowsPhone.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService)
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            _navigationService = navigationService;

            PageTitle = "First Page";
        }

        //public MainViewModel()
        //{

        //}

        private readonly INavigationService _navigationService;


        private string _pageTitle ;

        public string PageTitle
        {
            get { return _pageTitle ?? "Default TItle"; }
            set
            {
                Set("PageTitle", ref _pageTitle, value);
            }
        }

        private RelayCommand _navigateToSecondPage;

        public RelayCommand NavigateToSecondPage
        {
            get
            {
                return _navigateToSecondPage ?? (_navigateToSecondPage = new RelayCommand( () =>_navigationService.NavigateTo(ViewModelLocator.SecondPageKey)));
            }
        }

        private RelayCommand _showWarning;

        public RelayCommand ShowWarning
        {
            get
            {
                return _showWarning 
                    ?? (_showWarning = new RelayCommand (
                        async () =>
                        {
                            var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                            await dialog.ShowMessage("This is a warning.", "Warning");
                        }));
            }
        }

        private RelayCommand _sendNotificationMessage;

        public RelayCommand SendNotificationMessage
        {
            get
            {
                return _sendNotificationMessage
                    ?? (_sendNotificationMessage = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send(
                            new NotificationMessageAction<string>(
                                "Testing",
                                reply =>
                                {
                                    PageTitle = reply;
                                }));
                    }));
            }
        }






    }
}