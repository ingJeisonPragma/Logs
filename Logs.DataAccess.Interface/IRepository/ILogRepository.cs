using Logs.DataAccess.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.DataAccess.Interface.IRepository
{
    public interface ILogRepository
    {
        Task<List<LogEntity>> GetAllLog();
        Task<List<LogEntity>> GetByApp(string App);
        Task<LogEntity> GetById(Guid Id);
        Task<bool> CreateLogItem(LogEntity entity);
        Task<bool> CreateLogDBContext(LogEntity entity);
    }
}
