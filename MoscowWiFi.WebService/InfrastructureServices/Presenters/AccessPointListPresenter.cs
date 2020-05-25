using System.Net;
using MoscowWiFi.WebService.ApplicationServices.GetAccessPointListUseCase;
using MoscowWiFi.WebService.ApplicationServices.Ports;
using Newtonsoft.Json;

namespace MoscowWiFi.WebService.InfrastructureServices.Presenters
{
    public class AccessPointListPresenter : IOutputPort<GetAccessPointListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public AccessPointListPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(GetAccessPointListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int) (response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success
                ? JsonConvert.SerializeObject(response.AccessPoints)
                : JsonConvert.SerializeObject(response.Message);
        }
    }
}