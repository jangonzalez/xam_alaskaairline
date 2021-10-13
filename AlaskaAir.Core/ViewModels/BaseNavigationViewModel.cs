using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace AlaskaAir.Core.ViewModels
{
    public class BaseNavigationViewModel : MvxNavigationViewModel
    {
        private bool _isRefreshing;
        private string _title;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public IMvxAsyncCommand BackAsyncCommand { get; private set; }
        public IMvxAsyncCommand RefreshAsyncCommand { get; private set; }

        public BaseNavigationViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            BackAsyncCommand = new MvxAsyncCommand(OnBackAsyncCommand);
            RefreshAsyncCommand = new MvxAsyncCommand(OnRefreshAsyncCommand);
        }

        protected virtual Task OnRefreshAsyncCommand()
        {
            return Task.FromResult(true);
        }

        protected virtual async Task OnBackAsyncCommand()
        {
            await NavigationService.Close(this);
        }
    }
}