using Microsoft.AspNetCore.Mvc;

namespace MoscowWiFi.WebService.InfrastructureServices.Presenters
{
    public class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json;charset=utf-8";
        }
    }
}