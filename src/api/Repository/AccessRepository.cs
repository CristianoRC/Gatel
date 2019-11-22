using System;
using System.Threading.Tasks;
using Dapper;
using Model.ValueObjects;

namespace Repository
{
    public class AccessRepository : BaseRepository, IAccessRepository
    {
        private readonly string _inserAccessRegister;

        public AccessRepository()
        {
            _inserAccessRegister = "insert into vehicle_checkin(plate,datetime) values(UPPER(@plate),@date)";
        }

        public async Task RegisterAccess(string plate)
        {
            using (var connection = GetConnection())
            {
                await connection.ExecuteAsync(_inserAccessRegister, new {plate = plate.ToUpper(), Date = DateTime.Now});
            }
        }
    }
}