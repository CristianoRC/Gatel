using System.Threading.Tasks;
using Model.Dto;

namespace Business
{
    public interface IVehicleBusiness
    {
        Task CreateVehicle(CreateVehicleDTO vehicleDto);
        Task DeleteVehicle(string plate);
    }
}