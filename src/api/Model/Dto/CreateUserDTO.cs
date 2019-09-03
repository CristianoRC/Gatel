using System.ComponentModel.DataAnnotations;

namespace Model.Dto
{
    public class CreateUserDto
    {
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string PassWord { get; set; }
        [Required] public string Apartament { get; set; }
        [Required] public string Phone { get; set; }
        [Required] public bool IsAdmin { get; set; }
    }
}