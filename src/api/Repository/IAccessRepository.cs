using System.Threading.Tasks;
using Model.ValueObjects;

namespace Repository
{
    public interface IAccessRepository
    {
        Task RegisterAccess(string plate);
    }
}