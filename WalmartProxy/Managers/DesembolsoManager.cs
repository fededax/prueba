using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WalmartProxy.Entidades;
using WalmartProxy.helpers;

namespace WalmartProxy.Managers
{
    public class DesembolsoManager
    {
        private readonly ProxyConfig proxyConfig = null;

        public DesembolsoManager(ProxyConfig config)
        {
            this.proxyConfig = config;
        }

        public async Task<List<EntidadEntrega>> GetEntidadEntrega(string token)
        {
            HttpSoaClient desW = new HttpSoaClient(proxyConfig.ServiceUrl);

            var response = await desW.GetRequestAsync<List<EntidadEntrega>>("/entidadentrega", token);
            return response;
        }

        public async Task<ControllerMultipleResponse> PostRequestDesembolso(DesembolsoRequest request,string token = null)
        {
            ControllerMultipleResponse result = new ControllerMultipleResponse();

            if (request != null)
            {
                HttpSoaClient desW = new HttpSoaClient(proxyConfig.ServiceUrl);

                try
                {
                    string content = JsonConvert.SerializeObject(request, new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });

                    var response = await desW.PostContentAsyncBase<ControllerMultipleResponse>("/desembolso/consulta", token,
                        new StringContent(content, System.Text.Encoding.UTF8, "application/json"));

                    if (response.data != null && response.data != null)
                    {
                        result.errorCode = response.errorCode;
                        result.errorMessage = response.errorMessage;
                        result.data = response.data;
                    }
                }
                catch (Exception ex)
                {
                    result.errorCode = 500;
                    result.errorMessage = string.Format("Ha ocurrido un error inesperado"+ ex);
                }
            }
            else
            {
                result.errorCode = 400;
                result.errorMessage = "Debe completar la información de la solicitud. Por favor verifique la documentacion.";
            }
            return result;
        }
    }
}
