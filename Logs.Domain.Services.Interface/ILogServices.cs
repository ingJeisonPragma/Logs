namespace Logs.Domain.Services.Interface
{
    public interface ILogServices
    {
        Task<bool> InsertLog();
        Task<IEnumerable<string>> GetAllLog();
    }
}