using System.ComponentModel.DataAnnotations;

namespace Model.Dto
{
    public class CreateVehicleDTO
    {
        public CreateVehicleDTO()
        {
        }

        public CreateVehicleDTO(string plate, string color, string model, string manufacturer,int userId)
        {
            Plate = plate;
            Color = color;
            Model = model;
            Manufacturer = manufacturer;
            UserId = userId;
        }

        [Required] public string Plate { get; set; }

        [Required] public string Color { get; set; }

        [Required] public string Model { get; set; }

        [Required] public string Manufacturer { get; set; }

        public int UserId { get; set; }
    }
}