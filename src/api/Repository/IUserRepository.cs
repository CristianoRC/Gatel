using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface IUserRepository
    {
        Task Create(User user);

        Task<IEnumerable<User>> GetAllUsers();
        
        Task<User> GetById(int userId);

        Task<User> UpdateData(User user);

        Task DeleteUser(int id);
    }
}