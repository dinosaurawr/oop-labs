using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoscowWiFi.WebService.DomainObjects;
using MoscowWiFi.WebService.DomainObjects.Ports;

namespace MoscowWiFi.WebService.ApplicationServices.Repositories
{
    public class InMemoryAccessPointRepository : IReadOnlyAccessPointRepository, IAccessPointRepository
    {
        private readonly List<AccessPoint> _accessPoints = new List<AccessPoint>();

        public InMemoryAccessPointRepository(IEnumerable<AccessPoint> accessPoints)
        {
            if (accessPoints != null)
            {
                _accessPoints.AddRange(accessPoints);
            }
        }
        
        public Task<AccessPoint> GetAccessPoint(long id)
        {
            return Task.FromResult(_accessPoints.FirstOrDefault(ap => ap.Id == id));
        }

        public Task<IEnumerable<AccessPoint>> GetAllAccessPoints()
        {
            return Task.FromResult(_accessPoints.AsEnumerable());
        }

        public Task<IEnumerable<AccessPoint>> QueryAccessPoints(ICriteria<AccessPoint> criteria)
        {
            return Task.FromResult(_accessPoints.Where(criteria.Filter.Compile()));
        }

        public Task AddAccessPoint(AccessPoint accessPoint)
        {
            _accessPoints.Add(accessPoint);
            return Task.CompletedTask;
        }

        public Task RemoveAccessPoint(AccessPoint accessPoint)
        {
            _accessPoints.Remove(accessPoint);
            return Task.CompletedTask;
        }

        public Task UpdateAccessPoint(AccessPoint accessPoint)
        {
            var foundAccessPoint = GetAccessPoint(accessPoint.Id).Result;
            if (foundAccessPoint == null)
            {
                AddAccessPoint(accessPoint);
            }
            else
            {
                if (accessPoint != foundAccessPoint)
                {
                    _accessPoints.Remove(foundAccessPoint);
                    _accessPoints.Add(accessPoint);
                }
            }
            return Task.CompletedTask;
        }
    }
}