using Model.ValueObjects;
using Newtonsoft.Json;

namespace Model.Dto.RequestPlate
{
    public class Result
    {
        public Box Box { get; set; }
        public string Plate { get; set; }
        [JsonProperty("Vehicle")] public VehicleResponse VehicleResponse { get; set; }
        public double Score { get; set; }
        public double Dscore { get; set; }
        public string FormattedPlate
        {
            get
            {
                if (Plate.Length == 7)
                    return $"{Plate.Substring(0, 3)}-{Plate.Substring(3, 4)}";

                return Plate;
            }
        }
    }
}