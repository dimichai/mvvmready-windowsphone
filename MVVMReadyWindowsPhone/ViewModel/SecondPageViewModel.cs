using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMReadyWindowsPhone.ViewModel
{
    public class SecondPageViewModel : MainViewModel
    {
        private readonly INavigationService _navigationService;

        public SecondPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            this.PageTitle = "Second Page";
        }

        private RelayCommand _navigateBack;

        public RelayCommand NavigateBack
        {
            get
            {
                return _navigateBack ?? (_navigateBack = new RelayCommand(() => _navigationService.GoBack()));
            }
        }

    }
}
