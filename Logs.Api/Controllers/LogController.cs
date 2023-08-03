using Logs.Domain.Business.DTO;
using Logs.Domain.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Logs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LogController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogServices _logServices;

        public LogController(IConfiguration configuration,
            ILogServices logServices)
        {
            this._configuration = configuration;
            this._logServices = logServices;
        }

        /// <summary>
        /// Se encarga de validar la funcionalidad de la Api.
        /// </summary>
        /// <response code="200">Devuelve si fue corecto.</response>
        [HttpGet]
        [Route("GetHealth")]
        public ActionResult GetHealth()
        {
            return StatusCode(200, true);
        }

        /// <summary>
        /// Se encarga de listar todos los logs registrados.
        /// </summary>
        /// <param name="page">Indica el número de la pagina, por defecto es 1.</param>
        /// <param name="take">Indica el número de datos por pagina, por defecto es 10.</param>
        /// <returns>Devuelve la lista de logs.</returns>
        /// <response code="200">Devuelve si fue corecto.</response>
        /// <response code="400">Devuelve el error.</response>
        [HttpGet]
        [Route("GetAllLogs")]
        public async Task<ActionResult> GetAllLogs(int page = 1, int take = 10)
        {
            try
            {
                var result = await _logServices.GetAllLog(page, take);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Se encarga de buscar el log por el Id.
        /// </summary>
        /// <param name="Id">Id del registro del Log.</param>
        /// <returns>Devuelve el log encontrado por Id.</returns>
        /// <response code="200">Devuelve si fue corecto.</response>
        /// <response code="400">Devuelve el error.</response>
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            try
            {
                var result = await _logServices.GetById(Id);

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Se encarga de listar todos los logs registrados a una aplicación.
        /// </summary>
        /// <param name="Application">Nombre de la aplicación con registros de Log.</param>
        /// <param name="page">Indica el número de la pagina, por defecto es 1.</param>
        /// <param name="take">Indica el número de datos por pagina, por defecto es 10.</param>
        /// <returns>Devuelve la lista de logs encontrados por aplicación.</returns>
        /// <response code="200">Devuelve si fue corecto.</response>
        /// <response code="400">Devuelve el error.</response>
        [HttpGet]
        [Route("GetByApp")]
        public async Task<ActionResult> GetByApp(string Application, int page = 1, int take = 10)
        {
            try
            {
                var result = await _logServices.GetByApp(Application, page, take);

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        } 

        /// <summary>
        /// Se encarga de registrar los logs.
        /// </summary>
        /// <param name="data">Recibe la lista con el string del logs que se va registrar.</param>
        /// <returns></returns>
        /// <response code="200">Devuelve si fue corecto el registro.</response>
        /// <response code="400">Devuelve el error.</response>
        [HttpPost]
        [Route("InsertLogs")]
        public async Task<ActionResult> InsertLogs([FromBody] LogRequestDTO data)
        {
            try
            {
                var result = await _logServices.InsertLog(data);

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
