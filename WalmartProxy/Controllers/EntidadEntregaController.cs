using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using WalmartProxy.Entidades;
using WalmartProxy.Managers;

namespace WalmartProxy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EntidadEntregaController : ControllerBase
    {
        private readonly ProxyConfig proxyConfig = null;
        private DesembolsoManager manager = null;

        /// <summary>
        /// Constructor del controller de E-Resumen
        /// </summary>
        /// <param name="options">Representa las configuraciones de acceso a datos</param>
        /// <param name="configuration">Representa la configuración particular del servicio de walmart</param>
        public EntidadEntregaController(IOptions<ProxyConfig> options, IConfiguration configuration)
        {
            this.proxyConfig = options.Value;
        }

        // GET: entidades
        [HttpGet]
        [Route("entidades")]
        public async Task<ActionResult<List<EntidadEntrega>>> Get()
        {
            var result = new List<EntidadEntrega>();
            try
            {
                var authentication = AuthenticationHeaderValue.Parse(Request.Headers[HeaderNames.Authorization]);

                manager = new DesembolsoManager(proxyConfig);

                result = await manager.GetEntidadEntrega(authentication.Parameter);
            }
                catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return result;
        }
    }
}