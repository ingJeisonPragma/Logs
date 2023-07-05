using Amazon.DynamoDBv2.Model;
using Logs.DataAccess.Interface.Entities;
using Logs.DataAccess.Interface.IRepository;
using Logs.Domain.Business.DTO;
using Logs.Domain.Business.Mapper;
using Logs.Domain.Business.Paginate;
using Logs.Domain.Services.Interface;

namespace Logs.Domain.Services
{
    public class LogServices : ILogServices
    {
        private readonly ILogRepository _logRepository;

        public LogServices(ILogRepository logRepository)
        {
            this._logRepository = logRepository;
        }

        //public async Task<bool> InsertLog(LogDTO logDTO)
        //{
        //    var entity = logDTO.MapTo<LogEntity>();
        //    entity.Pk = Guid.NewGuid();
        //    var result = await _logRepository.CreateLogItem(entity);

        //    return true;
        //}

        public async Task<bool> InsertLog(LogRequestDTO logDTO)
        {
            var entity = logDTO.MapTo<LogEntity>();
            entity.Pk = Guid.NewGuid();
            var result = await _logRepository.CreateLogDBContext(entity);

            return result;
        }

        public async Task<PaginatedListDTO<LogResponseDTO>> GetAllLog(int page, int take)
        {
            var entity = await _logRepository.GetAllLog();
            var Dto = entity.MapTo<List<LogResponseDTO>>();
            var result = PagingExtension<LogResponseDTO>.GetPaged(Dto, page, take);
            return result;
        }

        public async Task<PaginatedListDTO<LogResponseDTO>> GetByApp(string App, int page, int take)
        {
            var entity = await _logRepository.GetByApp(App);
            var Dto = entity.MapTo<List<LogResponseDTO>>();
            var result = PagingExtension<LogResponseDTO>.GetPaged(Dto, page, take);
            return result;
        }

        public async Task<LogResponseDTO> GetById(Guid Id)
        {
            var entity = await _logRepository.GetById(Id);
            var Dto = entity.MapTo<LogResponseDTO>();
            return Dto;
        }
    }
}