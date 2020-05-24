using System.Collections.Generic;
using System.Threading.Tasks;
using MoscowWiFi.WebService.ApplicationServices.Ports;
using MoscowWiFi.WebService.DomainObjects;
using MoscowWiFi.WebService.DomainObjects.Ports;

namespace MoscowWiFi.WebService.ApplicationServices.GetAccessPointListUseCase
{
    public class GetAccessPointListUseCase : IGetAccessPointListUseCase
    {
        private readonly IReadOnlyAccessPointRepository _readOnlyAccessPointRepository;

        public GetAccessPointListUseCase(IReadOnlyAccessPointRepository readOnlyAccessPointRepository) 
            => _readOnlyAccessPointRepository = readOnlyAccessPointRepository;

        public async Task<bool> Handle(GetAccessPointListUseCaseRequest request, IOutputPort<GetAccessPointListUseCaseResponse> outputPort)
        {
            IEnumerable<AccessPoint> accessPoints = null;
            if (request.AccessPointId != null)
            {
                var accessPoint = await _readOnlyAccessPointRepository.GetAccessPoint(request.AccessPointId.Value);
                accessPoints = (accessPoint != null) ? new List<AccessPoint>() {accessPoint} : new List<AccessPoint>();
            }
            else
            {
                accessPoints = await _readOnlyAccessPointRepository.GetAllAccessPoints();
            }
            
            outputPort.Handle(new GetAccessPointListUseCaseResponse(accessPoints));
            return true;
        }
    }
}