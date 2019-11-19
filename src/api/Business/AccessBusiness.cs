using System.Linq;
using System.Threading.Tasks;
using Business.PlateRecognizer;

namespace Business
{
    class AccessBusiness : IAccessBusiness
    {
        private readonly IPlateRecognizer _plateRecognizer;
        private readonly IVehicleBusiness _vehicleBusiness;

        public AccessBusiness(IPlateRecognizer plateRecognizer, IVehicleBusiness vehicleBusiness)
        {
            _plateRecognizer = plateRecognizer;
            _vehicleBusiness = vehicleBusiness;
        }

        public async Task<bool> CarCanAccess(string imageBase64)
        {
            var conversionData = await _plateRecognizer.GetPlate(imageBase64);

            if (conversionData.Results.Any())
            {
                var plate = conversionData.Results.First().Plate;

                if (plate.Length == 7)
                    plate = $"{plate.Substring(0, 3)}-{plate.Substring(3, 4)}";

                return await _vehicleBusiness.VehicleExists(plate);
            }

            return false;
        }
    }
}