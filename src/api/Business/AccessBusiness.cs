using System.Threading.Tasks;
using Business.PlateRecognizer;

namespace Business
{
    class AccessBusiness : IAccessBusiness
    {
        private readonly IPlateRecognizer _plateRecognizer;

        public AccessBusiness(IPlateRecognizer plateRecognizer)
        {
            _plateRecognizer = plateRecognizer;
        }
        
        public async Task<bool> CarCanAccess(string imageBase64)
        {
            var conversionData = await _plateRecognizer.GetPlate(imageBase64);

            return true;
        }
    }
}