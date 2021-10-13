using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Microsoft.Extensions.Logging;
using Models.Common;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Services.Exceptions;
using Services.Interfaces;

namespace AlaskaAir.Core.ViewModels
{
    public class FlightsViewModel : BaseNavigationViewModel, IMvxViewModel<FlightSearchRequest>
    {
        private readonly IFlightSearchService _flightSearchService;
        private FlightSearchRequest _request;
        private IUserDialogs _userDialogs;
        private CancellationTokenSource _cancellationTokenSource;

        public MvxObservableCollection<Flight> Flights { get; private set; }


        public FlightsViewModel(ILoggerFactory logFactory,
            IMvxNavigationService navigationService,
            IFlightSearchService flightSearchService,
            IUserDialogs userDialogs) : base(logFactory, navigationService)
        {
            _flightSearchService = flightSearchService;
            _userDialogs = userDialogs;

            Title = "Flight Results";
            Flights = new MvxObservableCollection<Flight>();
        }

        public async Task RefreshFlights()
        {
            if (_cancellationTokenSource == null)
            {
                _cancellationTokenSource = new CancellationTokenSource();
            }

            IsRefreshing = true;
            var flights = await _flightSearchService.GetFlightsAsync(_request, _cancellationTokenSource.Token);
            IsRefreshing = false;

            if (flights != null && flights.Any())
            {
                Flights.Clear();
                Flights.AddRange(flights);
            }
            else
            {
                await _userDialogs.AlertAsync("No results", "Info", "OK");
                await NavigationService.Close(this);
            }

            _cancellationTokenSource.Token.ThrowIfCancellationRequested();
        }

        protected override async Task OnRefreshAsyncCommand()
        {
            try
            {
                await RefreshFlights();
            }
            catch (OperationCanceledException opc)
            {
                IsRefreshing = false;
                Console.WriteLine(opc.Message);
                await NavigationService.Close(this);
            }
            catch (APIErrorException api)
            {
                IsRefreshing = false;
                Console.WriteLine(api.ApiError);
                await _userDialogs.AlertAsync(api.ApiError, "Ops!", "OK");
                await NavigationService.Close(this);
            }
            catch (Exception ex)
            {
                IsRefreshing = false;
                Console.WriteLine(ex.Message);
                await _userDialogs.AlertAsync("Something went wrong, please try again", "Ops!", "OK");
                await NavigationService.Close(this);
            }
            finally
            {
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }

        public void Prepare(FlightSearchRequest parameter)
        {
            _request = parameter;
            RefreshAsyncCommand.Execute();
        }

        protected override async Task OnBackAsyncCommand()
        {
            _cancellationTokenSource?.Cancel();
            await base.OnBackAsyncCommand();
        }
    }
}
