using System;
using AlaskaAir.Core.ViewModels;
using Microsoft.Extensions.Logging;
using Moq;
using MvvmCross.Navigation;
using Xunit;

namespace AlaskaAir.Tests.ViewModels
{
    public class FlightSearchViewModelTests : MvxIoCSupportingTest
    {
        [Fact]
        public void CheckViewModelParametersForSearching()
        {
            var origin = "SEA";
            var destination = "LAX";
            var depatureDate = DateTime.Now;
            var logger = Ioc.Resolve<ILoggerFactory>();
            var navigation = Ioc.Resolve<IMvxNavigationService>();
            var flightSearchViewModel = new FlightSearchViewModel(logger, navigation);
            flightSearchViewModel.OriginCode = origin;
            flightSearchViewModel.DestinationCode = destination;
            flightSearchViewModel.DepartureTime = depatureDate;
            flightSearchViewModel.SearchAsyncCommand.Execute();
            Assert.Equal(origin, flightSearchViewModel.OriginCode);
            Assert.Equal(destination, flightSearchViewModel.DestinationCode);
            Assert.Equal(depatureDate, flightSearchViewModel.DepartureTime);
        }
    }
}
