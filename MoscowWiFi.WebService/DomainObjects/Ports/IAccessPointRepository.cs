using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoscowWiFi.WebService.DomainObjects.Ports
{
    public interface IReadOnlyAccessPointRepository
    {
        Task<AccessPoint> GetAccessPoint(long id);
        Task<IEnumerable<AccessPoint>> GetAllAccessPoints();
        Task<IEnumerable<AccessPoint>> QueryAccessPoints(ICriteria<AccessPoint> criteria);
    }
    
    public interface IAccessPointRepository
    {
        Task AddAccessPoint(AccessPoint accessPoint);
        Task RemoveAccessPoint(AccessPoint accessPoint);
        Task UpdateAccessPoint(AccessPoint accessPoint);
    }
}