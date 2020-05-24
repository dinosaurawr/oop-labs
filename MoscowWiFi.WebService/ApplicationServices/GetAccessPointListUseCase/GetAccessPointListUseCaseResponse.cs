using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using MoscowWiFi.WebService.ApplicationServices.Interfaces;
using MoscowWiFi.WebService.DomainObjects;

namespace MoscowWiFi.WebService.ApplicationServices.GetAccessPointListUseCase
{
    public class GetAccessPointListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<AccessPoint> AccessPoints { get; }

        public GetAccessPointListUseCaseResponse(IEnumerable<AccessPoint> accessPoints)
            => AccessPoints = accessPoints;
    }
}