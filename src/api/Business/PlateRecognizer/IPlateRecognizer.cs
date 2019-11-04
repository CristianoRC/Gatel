using System.Threading.Tasks;
using Model.Dto.RequestPlate;

namespace Business.PlateRecognizer
{
    public interface IPlateRecognizer
    {
        Task<ResponsePlateRecognizer> GetPlate(string imageBase64);
    }
}