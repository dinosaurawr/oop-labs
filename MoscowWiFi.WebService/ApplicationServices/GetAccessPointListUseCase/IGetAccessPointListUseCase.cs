using MoscowWiFi.WebService.ApplicationServices.Interfaces;

namespace MoscowWiFi.WebService.ApplicationServices.GetAccessPointListUseCase
{
    public interface IGetAccessPointListUseCase :
        IUseCase<GetAccessPointListUseCaseRequest, GetAccessPointListUseCaseResponse>
    {
    }
}