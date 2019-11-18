using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using Model.Dto;
using Model.ValueObjects;
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
            var vehicle = Vehicle.FromCreateDto(vehicleDto);

            if (vehicle.IsValid())
                await _vehicleRepository.CreateVehicle(vehicle);
            else
                throw new ArgumentException("Dado(s) do veículo inválido(s), verifique todos os campos!");
        }

        public async Task DeleteVehicle(string plate)
        {
            await _vehicleRepository.DeleteVehicle(new Plate(plate));
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await _vehicleRepository.GetAll();
        }
    }
}