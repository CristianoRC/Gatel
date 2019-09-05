using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using Model.Dto;

namespace Business
{
    public interface IUserBusiness
    {
        Task Create(CreateUserDto user);

        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int userId);

        Task<User> UpdateData(CreateUserDto user, int id);

        Task DeleteUser(int id);
    }
}