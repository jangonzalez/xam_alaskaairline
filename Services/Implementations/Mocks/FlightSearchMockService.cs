using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Models.Common;
using Services.Interfaces;

namespace Services.Implementations.Mocks
{
    public class FlightSearchMockService : IFlightSearchService
    {
        public async Task<IEnumerable<Flight>> GetFlightsAsync(FlightSearchRequest request, CancellationToken? token = null)
        {
            var list = new List<Flight>();

            for (var i = 0; i < 40; i++)
            {
                list.Add(new Flight()
                {
                     FlightNumber = $"AL {i}",
                     OriginCode = request.OriginCode,
                     DestinationCode = request.DestinationCode,
                     ArrivalTime = request.ArrivalTime,
                     DepartureTime = request.DepartureTime
                });
            }

            if (token.HasValue)
            {
                await Task.Delay(TimeSpan.FromSeconds(1.5), token.Value);
            }
            else
            {
                await Task.Delay(TimeSpan.FromSeconds(1.5));
            }
            return list;
        }
    }
}
