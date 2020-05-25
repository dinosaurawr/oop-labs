using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoscowWiFi.WebService.ApplicationServices.GetAccessPointListUseCase;
using MoscowWiFi.WebService.DomainObjects;
using MoscowWiFi.WebService.InfrastructureServices.Presenters;

namespace MoscowWiFi.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessPointsController : ControllerBase
    {
        private readonly ILogger<AccessPointsController> _logger;
        private readonly IGetAccessPointListUseCase _getAccessPointListUseCase;

        public AccessPointsController(ILogger<AccessPointsController> logger,
            IGetAccessPointListUseCase getAccessPointListUseCase)
        {
            _logger = logger;
            _getAccessPointListUseCase = getAccessPointListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAccessPoints()
        {
            var presenter = new AccessPointListPresenter();
            await _getAccessPointListUseCase.Handle(GetAccessPointListUseCaseRequest.CreateAllAccessPointsRequest(),
                presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{accessPointId}")]
        public async Task<ActionResult> GetAccessPoint(long accessPointId)
        {
            var presenter = new AccessPointListPresenter();
            await _getAccessPointListUseCase.Handle(GetAccessPointListUseCaseRequest.CreateAccessPointRequest(accessPointId),
                presenter);
            return presenter.ContentResult;
        }
    }
}