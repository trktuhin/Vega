using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Persistence
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int id,bool hasAdditional=true);
         void Add(Vehicle vehicle);
         void Remove(Vehicle vehicle);
         Task<IEnumerable<Vehicle>> GetVehicles();
    }
}