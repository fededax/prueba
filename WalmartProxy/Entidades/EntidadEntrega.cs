using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartProxy.Entidades
{
    public partial class EntidadEntrega
    {
        public byte IdEntidadEntrega { get; set; }
        public string Descripcion { get; set; }
        public string Contacto { get; set; }
        public Nullable<byte> IdEmpresa { get; set; }
        public Nullable<short> IdSucursal { get; set; }
        public string Mensajeria { get; set; }
        public Nullable<byte> IdControlPago { get; set; }
        public string LASTUIDUPDUSERID { get; set; }
        public Nullable<System.DateTime> LASTDATEUPD { get; set; }
        public string MENSAJERIATA { get; set; }
        public Nullable<short> MENSAJEPARAMID { get; set; }
        public string LUGARCOBRO { get; set; }
    }
}
