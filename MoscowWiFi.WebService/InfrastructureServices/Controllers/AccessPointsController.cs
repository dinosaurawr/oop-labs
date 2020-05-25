using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoscowWiFi.WebService.DomainObjects;

namespace MoscowWiFi.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessPointsController : ControllerBase
    {
        private readonly ILogger<AccessPointsController> _logger;

        public AccessPointsController(ILogger<AccessPointsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<AccessPoint> GetAllAccessPoints()
        {
            return new List<AccessPoint>()
            {
                new AccessPoint()
                {
                    District = "123",
                    Location = "123",
                    Password = "123",
                    Name = "123",
                    AccessFlag = "asda",
                    AdmArea = "asdasd",
                    CoverageArea = 400,
                    FunctionFlag = "asdasd",
                    WiFiName = "asda",
                    NumberOfAccessPoints = 2,
                    Id = 123123123
                }
            };
        }
    }
}