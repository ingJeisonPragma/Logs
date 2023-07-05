using Logs.Domain.Business.DTO;
using Logs.Domain.Business.Paginate;

namespace Logs.Domain.Services.Interface
{
    public interface ILogServices
    {
        Task<bool> InsertLog(LogRequestDTO logDTO);
        Task<PaginatedListDTO<LogResponseDTO>> GetAllLog(int page, int take);
        Task<PaginatedListDTO<LogResponseDTO>> GetByApp(string App, int page, int take);
        Task<LogResponseDTO> GetById(Guid Id);
    }
}