using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Models.Common;

namespace Services.Interfaces
{
    public interface IFlightSearchService
    {
        Task<IEnumerable<Flight>> GetFlightsAsync(FlightSearchRequest request, CancellationToken? token = null);
    }
}
