using System;
using System.Linq.Expressions;

namespace MoscowWiFi.WebService.DomainObjects.Ports
{
    public interface ICriteria<T> where T : DomainObject
    {
        Expression<Func<T, bool>> Filter { get; }
    }
}