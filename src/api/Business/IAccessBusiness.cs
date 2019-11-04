using System.Threading.Tasks;

namespace Business
{
    public interface IAccessBusiness
    {
        Task<bool> CarCanAccess(string imageBase64);
    }
}