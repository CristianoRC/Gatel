using System;
using System.Threading.Tasks;
using Model;
using Model.Dto;
using Repository;

namespace Business
{
    public class VehicleBusiness : IVehicleBusiness
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleBusiness(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task CreateVehicle(CreateVehicleDTO vehicleDto)
        {
            var vehicle = new Vehicle(vehicleDto);

            if (vehicle.IsValid())
                await _vehicleRepository.CreateVehicle(vehicle);
            else
                throw new ArgumentException("Dado(s) do veículo inválido(s), verifique todos os campos!");
        }

        public async Task DeleteVehicle(string plate)
        {
            throw new System.NotImplementedException();
        }
    }
}