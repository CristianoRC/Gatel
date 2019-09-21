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

        public VehicleRepository()
        {
            _createVehicleSql = "insert into vehicle values(@plate,@color,@model,@manufacturer,@isDeleted)";
            _addUserVehicleSql = "insert into users_vehicles values(@plate,@userId)";
        }

        public async Task CreateVehicle(Vehicle vehicle)
        {
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

        public Task DeleteVehicle(Plate plate)
        {
            throw new NotImplementedException();
        }
    }
}