namespace MoscowWiFi.WebService.ApplicationServices.Interfaces
{
    public abstract class UseCaseResponse
    {
        public bool Success { get; }
        
        public string Message { get; }

        public UseCaseResponse(bool success = true, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}