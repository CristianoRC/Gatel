using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using Model.Dto;

namespace Repository
{
    public interface IUserRepository
    {
        Task Create(User user);

        Task<IEnumerable<User>> GetAllUsers();
        
        Task<User> GetById(int userId);

        Task UpdateData(UpdateUserDTO user,int id);

        Task DeleteUser(int id);
    }
}