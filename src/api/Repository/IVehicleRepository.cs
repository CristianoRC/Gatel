using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using Model.ValueObjects;

namespace Repository
{
    public interface IVehicleRepository
    {
        Task CreateVehicle(Vehicle vehicle);
        Task DeleteVehicle(Plate plate);
        Task<IEnumerable<Vehicle>> GetAll();
    }
}