using Npgsql;

namespace Repository
{
    public abstract class BaseRepository
    {
        private readonly string _stringConnection;

        protected BaseRepository()
        {
            _stringConnection =
                "User ID=postgres;Password=123456789;Host=172.17.0.2;Port=5432;Database=vehicle_access_control;";
        }

        protected NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_stringConnection);
        }
    }
}