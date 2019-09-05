using System.ComponentModel.DataAnnotations;
using Model.Dto;
using Model.ValueObjects;

namespace Model
{
    public class User
    {
        public User(int id, string name, Email email, string passWord, string apartament, string phone, bool isDeleted,
            bool isAdmin)
        {
            Id = id;
            Name = name;
            Email = email;
            PassWord = passWord;
            Apartament = apartament;
            Phone = phone;
            IsDeleted = isDeleted;
            IsAdmin = isAdmin;
        }

        public User()
        {
        }

        public User(CreateUserDto userDto)
        {
            Apartament = userDto.Apartament;
            Email = new Email(userDto.Email);
            Name = userDto.Name;
            Phone = userDto.Phone;
            IsAdmin = userDto.IsAdmin;
            IsDeleted = false;
            PassWord = userDto.PassWord;
        }

        public User(UserQuery userQuery)
        {
            Name = userQuery.Name;
            Email = new Email(userQuery.Email);
            Apartament = userQuery.Apartament;
            Id = userQuery.Id;
            Phone = userQuery.Name;
            IsAdmin = userQuery.IsAdmin;
            IsDeleted = false;
            PassWord = userQuery.PassWord;
        }

        public User(string name, string email, string phone, string apartament, bool isAdmin)
        {
            IsDeleted = false;
            IsAdmin = isAdmin;
            Name = name;
            Email = new Email(email);
            Phone = phone;
            Apartament = apartament;
        }

        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public Email Email { get; set; }

        [Required] public string PassWord { get; set; }

        [Required] public string Apartament { get; set; }

        [Required] public string Phone { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsDeleted { get; set; }
    }
}