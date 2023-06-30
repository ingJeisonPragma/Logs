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

        public LogController(IConfiguration configuration)
        {
            this._configuration = configuration;
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
        public async Task<ActionResult> GetAllLogs(int page = 1, int take = 10)
        {
            try
            {
                return StatusCode(200, new string[] { "value1", "value2" });
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
        public async Task<ActionResult> InsertLogs([FromBody] List<string> data)
        {
            try
            {
                return StatusCode(200, true);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
