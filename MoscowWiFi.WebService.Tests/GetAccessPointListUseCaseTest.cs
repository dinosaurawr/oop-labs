using System.Collections.Generic;
using System.Linq;
using MoscowWiFi.WebService.ApplicationServices.GetAccessPointListUseCase;
using MoscowWiFi.WebService.ApplicationServices.Ports;
using MoscowWiFi.WebService.ApplicationServices.Repositories;
using MoscowWiFi.WebService.DomainObjects;
using Xunit;

namespace MoscowWiFi.WebService.Tests
{
    public class GetAccessPointListUseCaseTest
    {
        private InMemoryAccessPointRepository CreateAccessPointRepository()
        {
            return new InMemoryAccessPointRepository(
                new List<AccessPoint>()
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
                        Id = 1
                    },
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
                        NumberOfAccessPoints = 3,
                        Id = 2
                    },
                });
        }

        [Fact]
        public void GetAllAccessPoints_FilledRepository_ReturnAllAccessPoints()
        {
            var useCase = new GetAccessPointListUseCase(CreateAccessPointRepository());
            var output = new OutputPort();

            Assert.True(useCase.Handle(GetAccessPointListUseCaseRequest.CreateAllAccessPointsRequest(), output).Result);
            Assert.Equal(2, output.AccessPoints.Count());
        }

        [Fact]
        public void GetAllAccessPoints_EmptyRepository_ReturnEmpty()
        {
            var useCase = new GetAccessPointListUseCase(new InMemoryAccessPointRepository(new List<AccessPoint>()));
            var output = new OutputPort();
            
            Assert.True(useCase.Handle(GetAccessPointListUseCaseRequest.CreateAllAccessPointsRequest(), output).Result);
            Assert.Empty(output.AccessPoints);
        }

        [Fact]
        public void GetAccessPoint_ExistingAccessPoint_RequestedAccessPoint()
        {
            var useCase = new GetAccessPointListUseCase(CreateAccessPointRepository());
            var output = new OutputPort();
            
            Assert.True(useCase.Handle(GetAccessPointListUseCaseRequest.CreateAccessPointRequest(2), output).Result);
            Assert.Single(output.AccessPoints, ap => ap.Id == 2);
        }

        [Fact]
        public void GetAccessPoint_NotExistingAccessPoint_Empty()
        {
            var useCase = new GetAccessPointListUseCase(CreateAccessPointRepository());
            var output = new OutputPort();
            
            Assert.True(useCase.Handle(GetAccessPointListUseCaseRequest.CreateAccessPointRequest(100), output).Result);
            Assert.Empty(output.AccessPoints);
        }
    }

    class OutputPort : IOutputPort<GetAccessPointListUseCaseResponse>
    {
        public IEnumerable<AccessPoint> AccessPoints { get; private set; }
        public void Handle(GetAccessPointListUseCaseResponse response)
        {
            AccessPoints = response.AccessPoints;
        }
    }
}