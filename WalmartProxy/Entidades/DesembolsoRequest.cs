using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartProxy.Entidades
{
    public class DesembolsoRequest
    {
        public int idEntidad { get; set; }
        public string Metodo { get; set; }
        public string InfoAdicional { get; set; }
        public int idTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
    }
}
