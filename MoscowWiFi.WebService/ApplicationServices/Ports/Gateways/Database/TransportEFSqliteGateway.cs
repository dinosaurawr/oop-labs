using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoscowWiFi.WebService.DomainObjects;

namespace MoscowWiFi.WebService.ApplicationServices.Ports.Gateways.Database
{
    public class TransportEFSqliteGateway : ITransportDatabaseGateway
    {
        private readonly MoscowWiFiContext _context;

        public TransportEFSqliteGateway(MoscowWiFiContext context) =>
            _context = context;
        
        public async Task AddAccessPoint(AccessPoint accessPoint)
        {
            _context.AccessPoints.Add(accessPoint);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAccessPoint(AccessPoint accessPoint)
        {
            _context.AccessPoints.Remove(accessPoint);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccessPoint(AccessPoint accessPoint)
        {
            _context.Entry(accessPoint).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<AccessPoint> GetAccessPoint(long id) =>
            await _context.AccessPoints.Where(ap => ap.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<AccessPoint>> GetAllAccessPoints() =>
            await _context.AccessPoints.ToListAsync();

        public async Task<IEnumerable<AccessPoint>> QueryAccessPoints(Expression<Func<AccessPoint, bool>> filter) =>
            await _context.AccessPoints.Where(filter).ToListAsync();
    }
}