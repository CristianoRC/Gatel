using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using Model.Dto;

namespace Business
{
    public interface IVehicleBusiness
    {
        Task CreateVehicle(CreateVehicleDTO vehicleDto);
        Task DeleteVehicle(string plate);

        Task<IEnumerable<Vehicle>> GetAll();
        Task<bool> VehicleExists(string plate);
    }
}