using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using Model.Dto;
using Repository;

namespace Business
{
    class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        //TODO: Validar os dados do usuário antes de mandar para o repository
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Create(CreateUserDto userDto)
        {
            //TODO: Validar se o usuário já foi excluido e quer apenas ser recriado
            var user = User.FromCreateDto(userDto);
            await _userRepository.Create(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetById(int userId)
        {
            if (userId < 0)
                throw new ArgumentException("Id do usuário inválido");

            return await _userRepository.GetById(userId);
        }

        public async Task UpdateData(UpdateUserDTO userDto, int id)
        {
            await _userRepository.UpdateData(userDto, id);
        }

        public async Task DeleteUser(int userId)
        {
            if (userId < 0)
                throw new ArgumentException("Id do usuário inválido");

            await _userRepository.DeleteUser(userId);
        }
    }
}