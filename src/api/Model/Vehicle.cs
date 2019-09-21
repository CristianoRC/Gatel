using Model.Dto;
using Model.ValueObjects;

namespace Model
{
    public class Vehicle
    {
        public Vehicle(Plate plate, string color, string model, string manufacturer, bool isDeleted, int userId)
        {
            Plate = plate;
            Color = color;
            Model = model;
            Manufacturer = manufacturer;
            IsDeleted = isDeleted;
            UserId = userId;
        }

        public Vehicle(string plate, string color, string model, string manufacturer, bool isDeleted, int userId)
        {
            Plate = new Plate(plate);
            Color = color;
            Model = model;
            Manufacturer = manufacturer;
            IsDeleted = isDeleted;
            UserId = userId;
        }

        public Vehicle(CreateVehicleDTO vehicleDto)
        {
            Plate = new Plate(vehicleDto.Plate);
            Color = vehicleDto.Color;
            Model = vehicleDto.Model;
            Manufacturer = vehicleDto.Manufacturer;
            IsDeleted = false;
            UserId = vehicleDto.UserId;
        }

        public Plate Plate { get; set; }

        public string Color { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public bool IsDeleted { get; set; }

        public int UserId { get; set; }


        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Color))
                return false;

            if (string.IsNullOrEmpty(Model))
                return false;

            if (string.IsNullOrEmpty(Manufacturer))
                return false;

            if (UserId < 0)
                return false;

            return true;
        }
    }
}