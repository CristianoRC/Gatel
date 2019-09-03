using System;
using System.Threading.Tasks;
using Model;
using Model.Dto;

namespace Business
{
    class UserBusiness : IUserBusiness
    {
        public async Task Create(CreateUserDto userDto)
        {
            var user = new User(userDto);
        }

        public async Task<User[]> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task GetById(int userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> UpdateData(CreateUserDto userDto, int id)
        {
            var user = new User(userDto);
            user.Id = id;

            throw new NotImplementedException();
        }

        public async Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}