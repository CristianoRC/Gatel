using System;
using System.Threading.Tasks;
using Dapper;
using Model;
using Model.ValueObjects;

namespace Repository
{
    class VehicleRepository : BaseRepository, IVehicleRepository
    {
        private readonly string _createVehicleSql;
        private readonly string _addUserVehicleSql;
        private readonly string _deleteVehicle;
        private readonly string _deleteUserVehicle;

        public VehicleRepository()
        {
            _createVehicleSql = "insert into vehicle values(@plate,@color,@model,@manufacturer,@isDeleted)";
            _addUserVehicleSql = "insert into users_vehicles values(@plate,@userId)";
            _deleteVehicle = "update vehicle set isDeleted = true where plate = @plate";
            _deleteUserVehicle = "delete from users_vehicles where plate = @plate";
        }

        public async Task CreateVehicle(Vehicle vehicle)
        {
            //TODO: Validar veículos deletados que querem ser reecriados
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    await connection.ExecuteAsync(_createVehicleSql,
                        new
                        {
                            Plate = vehicle.Plate.Value, vehicle.Color, vehicle.Model,
                            vehicle.Manufacturer, vehicle.IsDeleted
                        }, transaction);

                    await connection.ExecuteAsync(_addUserVehicleSql,
                        new {Plate = vehicle.Plate.Value, vehicle.UserId}, transaction);

                    await transaction.CommitAsync();
                }
            }
        }

        public async Task DeleteVehicle(Plate plate)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    await connection.ExecuteAsync(_deleteVehicle, new {Plate = plate.Value}, transaction);
                    await connection.ExecuteAsync(_deleteUserVehicle, new {Plate = plate.Value}, transaction);
                    await transaction.CommitAsync();
                }
            }
        }
    }
}