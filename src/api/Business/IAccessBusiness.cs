using System.Threading.Tasks;
using Model.ValueObjects;

namespace Business
{
    public interface IAccessBusiness
    {
        Task<bool> CarCanAccess(string imageBase64);
    }
}