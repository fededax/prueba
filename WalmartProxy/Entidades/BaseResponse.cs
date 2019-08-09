using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartProxy.Entidades
{
    /// <summary>
    /// Clase que contiene la información devuelta por un método GET de un controlador del proyecto de Desembolsos
    /// </summary>
    public class ControllerResponse : ControllerErrorDescription
    {
        /// <summary>
        /// Contiene la información del objeto sobre el que se realiza el request
        /// </summary>
        public object data { get; set; }
    }

    /// <summary>
    /// Clase que contiene la información devuelta por un método GET de un controlador del proyecto de Desembolsos.
    /// Adicionalmente, en el caso en que se devuelva una lista de elementos, contiene la información de paginado y total de rows de la entidad del request
    /// </summary>
    public class ControllerMultipleResponse : ControllerResponse
    {
        /// <summary>
        /// Determina a partir de qué elemento devolverá la información solicitada
        /// </summary>
        public int offset { get; set; }
        /// <summary>
        /// Determina la cantidad de elementos que conformará la lista de respuesta
        /// </summary>
        public int limit { get; set; }
        /// <summary>
        /// Indica la cantidad de registros con las que cuenta la entidad sobre la que se realiza la consulta
        /// </summary>
        public int total { get; set; }
    }

    /// <summary>
    /// Clase que contiene la información del error encontrado en la operación
    /// </summary>
    public class ControllerErrorDescription
    {
        /// <summary>
        /// Indica el codigo del error detectado
        /// </summary>
        public int errorCode { get; set; }
        /// <summary>
        /// Describe el detalle del error detectado
        /// </summary>
        public string errorMessage { get; set; }
    }

}
