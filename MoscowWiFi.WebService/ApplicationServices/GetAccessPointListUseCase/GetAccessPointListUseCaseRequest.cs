using MoscowWiFi.WebService.ApplicationServices.Interfaces;

namespace MoscowWiFi.WebService.ApplicationServices.GetAccessPointListUseCase
{
    public class GetAccessPointListUseCaseRequest : IUseCaseRequest<GetAccessPointListUseCaseResponse>
    {
        public long? AccessPointId { get; set; }

        private GetAccessPointListUseCaseRequest()
        { }

        public static GetAccessPointListUseCaseRequest CreateAllAccessPointsRequest()
        {
            return new GetAccessPointListUseCaseRequest();
        }

        public static GetAccessPointListUseCaseRequest CreateAccessPointRequest(long accessPointId)
        {
            return new GetAccessPointListUseCaseRequest() { AccessPointId = accessPointId };
        }
    }
}