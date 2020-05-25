using System.Collections.Generic;
using System.Threading.Tasks;
using MoscowWiFi.WebService.ApplicationServices.Ports.Gateways.Database;
using MoscowWiFi.WebService.DomainObjects;
using MoscowWiFi.WebService.DomainObjects.Ports;

namespace MoscowWiFi.WebService.ApplicationServices.Repositories
{
    public class DbAccessPointRepository : IReadOnlyAccessPointRepository,
        IAccessPointRepository
    {
        private readonly ITransportDatabaseGateway _gateway;

        public DbAccessPointRepository(ITransportDatabaseGateway databaseGateway) =>
            _gateway = databaseGateway; 
        public async Task<AccessPoint> GetAccessPoint(long id) =>
            await _gateway.GetAccessPoint(id);

        public async Task<IEnumerable<AccessPoint>> GetAllAccessPoints() =>
            await _gateway.GetAllAccessPoints();

        public async Task<IEnumerable<AccessPoint>> QueryAccessPoints(ICriteria<AccessPoint> criteria) =>
            await _gateway.QueryAccessPoints(criteria.Filter);

        public async Task AddAccessPoint(AccessPoint accessPoint) =>
            await _gateway.AddAccessPoint(accessPoint);

        public async Task RemoveAccessPoint(AccessPoint accessPoint) =>
            await _gateway.RemoveAccessPoint(accessPoint);

        public async Task UpdateAccessPoint(AccessPoint accessPoint) =>
            await _gateway.UpdateAccessPoint(accessPoint);
    }
}