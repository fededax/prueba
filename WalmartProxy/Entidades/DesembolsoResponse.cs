using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartProxy.Entidades
{
    public class DesembolsoResponse
    {
        public short IdEmpresaBookeo { get; set; }
        public long IdPrestamo { get; set; }
        public string NumeroPrestamo { get; set; }
        public short IdRetailerCW { get; set; }
        public long IdSolicitudCW { get; set; }
        public decimal Monto { get; set; }
        public decimal IdCliente { get; set; }
        public short IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public byte Estado { get; set; }
        public Nullable<System.DateTime> FechaEstado { get; set; }
        public string TRANSACC { get; set; }
        public byte ACREFORMAID { get; set; }
        public byte IdEnteEntrega { get; set; }
        public string Metodo { get; set; }
        public string CBU { get; set; }
        public string TipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public byte NumeroCuotas { get; set; }
        public short CodigoSucursal { get; set; }
        public string SUCDESC { get; set; }
    }
}
