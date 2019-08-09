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
    public class DesembolsoController : ControllerBase
    {
        private DesembolsoManager manager = null;
        private readonly ProxyConfig proxyConfig = null;

        public DesembolsoController(IOptions<ProxyConfig> options, IConfiguration configuration)
        {
            this.proxyConfig = options.Value;
        }

        // Post: consulta
        [HttpPost]
        [Route("consulta")]
        public async Task<ActionResult<ControllerMultipleResponse>> PostConsulta(DesembolsoRequest request)
        {
            ControllerMultipleResponse result = new ControllerMultipleResponse();
            manager = new DesembolsoManager(proxyConfig);
            var authentication = AuthenticationHeaderValue.Parse(Request.Headers[HeaderNames.Authorization]);

            result = await manager.PostRequestDesembolso(request, authentication.Parameter);
            return result;
        }
    }
}
