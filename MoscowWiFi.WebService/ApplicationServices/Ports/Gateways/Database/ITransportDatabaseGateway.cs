using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using MoscowWiFi.WebService.DomainObjects;

namespace MoscowWiFi.WebService.ApplicationServices.Ports.Gateways.Database
{
    public interface ITransportDatabaseGateway
    {
        Task AddAccessPoint(AccessPoint accessPoint);

        Task RemoveAccessPoint(AccessPoint accessPoint);

        Task UpdateAccessPoint(AccessPoint accessPoint);

        Task<AccessPoint> GetAccessPoint(long id);

        Task<IEnumerable<AccessPoint>> GetAllAccessPoints();

        Task<IEnumerable<AccessPoint>> QueryAccessPoints(Expression<Func<AccessPoint, bool>> filter);
    }
}