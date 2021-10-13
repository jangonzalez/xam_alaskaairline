using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using AlaskaAir.Core.ViewModels;
using Microsoft.Extensions.Logging;
using Models.Common;
using MvvmCross.Navigation;
using Services.Exceptions;
using Services.Interfaces;
using Xunit;

namespace AlaskaAir.Tests.ViewModels
{
    public class FlightsViewModelTests : MvxIoCSupportingTest
    {
        [Fact]
        public async Task Check_FlightService_For_Invalid_Dates()
        {
            var origin = "SEA";
            var destination = "LAX";
            var depatureDate = DateTime.MinValue;

            var navigation = Ioc.Resolve<IMvxNavigationService>();
            var logger = Ioc.Resolve<ILoggerFactory>();
            var flightService = Ioc.Resolve<IFlightSearchService>();
            var dialogs = Ioc.Resolve<IUserDialogs>();

            var flightsViewModel = new FlightsViewModel(logger, navigation, flightService, dialogs);

            var request = new FlightSearchRequest()
            {
                OriginCode = origin,
                DestinationCode = destination,
                DepartureTime = depatureDate,
                ArrivalTime = depatureDate
            };

            flightsViewModel.Prepare(request);
            await flightsViewModel.RefreshFlights();
            Assert.Empty(flightsViewModel.Flights);
        }

        [Fact]
        public async Task Check_FlightService_For_Valid_Dates()
        {
            var origin = "SEA";
            var destination = "LAX";
            var depatureDate = DateTime.Now;

            var navigation = Ioc.Resolve<IMvxNavigationService>();
            var logger = Ioc.Resolve<ILoggerFactory>();
            var flightService = Ioc.Resolve<IFlightSearchService>();
            var dialogs = Ioc.Resolve<IUserDialogs>();

            var flightsViewModel = new FlightsViewModel(logger, navigation, flightService, dialogs);

            var request = new FlightSearchRequest()
            {
                OriginCode = origin,
                DestinationCode = destination,
                DepartureTime = depatureDate,
                ArrivalTime = depatureDate
            };

            flightsViewModel.Prepare(request);
            await flightsViewModel.RefreshFlights();

            Assert.NotEmpty(flightsViewModel.Flights);
        }

        [Fact]
        public async Task Throw_API_Error_Exception()
        {
            var origin = "SEA";
            var destination = "LAX";
            //exceptions when there are more than 3 days
            //between departure and arrival
            var depatureDate = DateTime.Now;
            var arrivalDate = DateTime.Now.AddDays(10);

            var navigation = Ioc.Resolve<IMvxNavigationService>();
            var logger = Ioc.Resolve<ILoggerFactory>();
            var flightService = Ioc.Resolve<IFlightSearchService>();
            var dialogs = Ioc.Resolve<IUserDialogs>();

            var flightsViewModel = new FlightsViewModel(logger, navigation, flightService, dialogs);

            var request = new FlightSearchRequest()
            {
                OriginCode = origin,
                DestinationCode = destination,
                DepartureTime = depatureDate,
                ArrivalTime = arrivalDate
            };

            flightsViewModel.Prepare(request);

            await Assert.ThrowsAsync<APIErrorException>(() => flightsViewModel.RefreshFlights());
        }
    }
}
