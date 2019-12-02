using System.Linq;
using System.Threading.Tasks;
using Business.PlateRecognizer;
using Model.ValueObjects;
using Repository;

namespace Business
{
    class AccessBusiness : IAccessBusiness
    {
        private readonly IPlateRecognizer _plateRecognizer;
        private readonly IVehicleBusiness _vehicleBusiness;
        private readonly IAccessRepository _accessRepository;

        public AccessBusiness(IPlateRecognizer plateRecognizer, IVehicleBusiness vehicleBusiness,
            IAccessRepository accessRepository)
        {
            _plateRecognizer = plateRecognizer;
            _vehicleBusiness = vehicleBusiness;
            _accessRepository = accessRepository;
        }

        public async Task<bool> CarCanAccess(string imageBase64)
        {
            var conversionData = await _plateRecognizer.GetPlate(imageBase64);

            if (conversionData.Results.Any())
            {
                var ocrResult = conversionData.Results.First();

                var userCanAccess = await _vehicleBusiness.VehicleExists(ocrResult.FormattedPlate);

                if (userCanAccess)
                {
                    await _accessRepository.RegisterAccess(ocrResult.FormattedPlate);
                    return true;
                }


                return false;
            }

            return false;
        }
    }
}