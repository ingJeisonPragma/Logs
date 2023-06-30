using Logs.Domain.Services.Interface;

namespace Logs.Domain.Services
{
    public class LogServices: ILogServices
    {
        public LogServices()
        {
            
        }

        public async Task<bool> InsertLog()
        {
            return true;
        }

        public async Task<IEnumerable<string>> GetAllLog()
        {
            IEnumerable<string> dato = new List<string>();
            return dato;
        }
    }
}