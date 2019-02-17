using AutoMapper;
using Domain.Health.DTO;
using Domain.Health.Handlers;
using iNomNomMenuApi.Controllers.GatewayAPI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iNomNomMenuApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HealthController: BaseController
    {
        public HealthController(IMapper mapper) : base(mapper)
        {
        }

        /// <summary>
        /// Checks the health of the API
        /// </summary>
        [ProducesResponseType(typeof(HealthDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<HealthDto> Get([FromServices] IHealthCheckHandler handler)
            => await handler.ExecuteAsync();
    }
}
