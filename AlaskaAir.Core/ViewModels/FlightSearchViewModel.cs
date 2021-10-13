using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models.Common;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Services.Interfaces;

namespace AlaskaAir.Core.ViewModels
{
    public class FlightSearchViewModel : BaseNavigationViewModel
    {
        private string _originCode;
        private string _destinationCode;
        private DateTime _departureTime;

        public string OriginCode
        {
            get => _originCode;
            set => SetProperty(ref _originCode, value);
        }

        public string DestinationCode
        {
            get => _destinationCode;
            set => SetProperty(ref _destinationCode, value);
        }

        public DateTime DepartureTime
        {
            get => _departureTime;
            set => SetProperty(ref _departureTime, value);
        }

        public IMvxAsyncCommand SearchAsyncCommand { get; private set; }

        public FlightSearchViewModel(ILoggerFactory logFactory,
            IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            Title = "Alaska Airlines";
            SearchAsyncCommand = new MvxAsyncCommand(OnSearchAsyncCommand);
        }

        private async Task OnSearchAsyncCommand()
        {
            //we need to check persmission before
            //to proceed, skip for now
            var request = new FlightSearchRequest()
            {
                OriginCode = OriginCode,
                DestinationCode = DestinationCode,
                DepartureTime = DepartureTime,
                //for now we just use departure for both
                //dates
                ArrivalTime = DepartureTime
            };
            await NavigationService.Navigate<FlightsViewModel, FlightSearchRequest>(request);
        }
    }
}