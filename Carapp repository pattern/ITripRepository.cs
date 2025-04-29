using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carapp_repository_pattern
{
    public interface ITripRepository
    {
        public IEnumerable<Trip> GetTripsForCar(string regNr);
        public void AddTrip(Trip trip);
        public void DeleteTrip(Trip trip);
    }
}
