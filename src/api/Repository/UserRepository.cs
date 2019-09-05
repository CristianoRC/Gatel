using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Dapper;
using Model;
using Model.Dto;
using Model.ValueObjects;

namespace Repository
{
    class UserRepository : BaseRepository, IUserRepository
    {
        public async Task Create(User user)
        {
            const string sql = @"insert into public.user (name,email,isAdmin,apartament,phone,isDeleted,passWord) 
                        Values(@Name,@Email,@IsAdmin,@Apartament,@Phone,@IsDeleted,@PassWord)";

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();

                await connection.ExecuteAsync(sql,
                    new
                    {
                        user.Name, Email = user.Email.Address,
                        user.IsAdmin, IsDeleted = false,
                        user.Apartament, user.Phone, user.PassWord
                    });

                connection.Close();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            const string sql =
                "select id, name, email, phone,apartament, isAdmin from public.user where isDeleted = false";

            var usersConverted = new List<User>();

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();

                var users = await connection.QueryAsync<UserQuery>(sql);

                foreach (var user in users)
                {
                    usersConverted.Add(new User(user));
                }
            }

            return usersConverted;
        }

        public async Task<User> GetById(int userId)
        {
            const string sql =
                "select id, name, email, phone,apartament, isAdmin from public.user where isDeleted = false and id = @userId";

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();

                var userQueryResult = await connection.QueryFirstAsync<UserQuery>(sql, new {userId});

                return new User(userQueryResult);
            }
        }

        public async Task UpdateData(UpdateUserDTO user, int id)
        {
            const string sql =
                @"update public.user set name = @Name, apartament = @Apartament, phone = @Phone where Id = @Id";

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();

                await connection.ExecuteAsync(sql,
                    new
                    {
                        user.Name,
                        user.Apartament,
                        user.Phone,
                        Id = id
                    });

                connection.Close();
            }
        }

        public async Task DeleteUser(int id)
        {
            const string sql = "update public.user set isDeleted=true where id = @Id";

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();

                await connection.ExecuteAsync(sql, new {Id = id});

                connection.Close();
            }
        }
    }
}