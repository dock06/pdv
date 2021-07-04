using PDV.Model;
using System;
using System.Data;

namespace PDV.Entities.Clientes
{
    /// <summary>
    /// Clase Proveedor contiene las propiedades de la tabla tblProveedor de la base de datos
    /// </summary>
    public class Cliente : Resultado
    {
        #region Propiedades
        public int ClaveCliente { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public string Correo { get; set; }
        public string RFC { get; set; }
        public int ClaveTipoCliente { get; set; }
        public int intAplicaCredito { get; set; }
        public string AplicaCredito { get; set; }
        public int intTipoCredito { get; set; }
        public string TipoCredito { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal CreditoDisponible { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int Status { get; set; }

        #endregion

        #region Metodos
        /// <summary>
        /// Método que sirve para consultar los proveedores del cátalogo de proveedores
        /// </summary>
        /// <returns>Regresa la lista de proveedores encontrados segun los parametros de busqueda</returns>
        public DataSet Consultar()
        {
            //Llenado de parametros para la consulta del cátalogo
            Parametros parametros = new Parametros();
            parametros.addParam("ClaveCliente", ClaveCliente);
            parametros.addParam("NombreCliente", Nombre);
            parametros.addParam("TipoCliente", ClaveTipoCliente);
            parametros.addParam("Estatus", Status);
            //Consultando SP por medio de la clase DB y el metodo executeSP 
            //pasando los parametros necesarios para la consulta
            //este metodo de la clase DB regresa un DataSet con los registro que
            //encontro en la base de datos.
            DataSet ds = DB.executeSP("SpConsultaClientes", parametros);
            if (ds.Tables[0].Rows.Count == 1)
            {
                this.ClaveCliente = int.Parse(ds.Tables[0].Rows[0]["Codigo"].ToString());
                this.Nombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
                this.ApPaterno = ds.Tables[0].Rows[0]["ApPaterno"].ToString();
                this.ApMaterno = ds.Tables[0].Rows[0]["ApMaterno"].ToString();
                this.Direccion = ds.Tables[0].Rows[0]["Direccion"].ToString();
                this.Telefono = ds.Tables[0].Rows[0]["Telefono"].ToString();
                this.Contacto = ds.Tables[0].Rows[0]["Contacto"].ToString();
                this.Correo = ds.Tables[0].Rows[0]["Correo"].ToString();
                this.RFC = ds.Tables[0].Rows[0]["RFC"].ToString();
                this.ClaveTipoCliente = int.Parse(ds.Tables[0].Rows[0]["ClaveTipoCliente"].ToString());
                this.AplicaCredito = ds.Tables[0].Rows[0]["AplicaCredito"].ToString();
                this.TipoCredito = ds.Tables[0].Rows[0]["TipoCredito"].ToString();
                this.LimiteCredito = decimal.Parse(ds.Tables[0].Rows[0]["LimiteCredito"].ToString());
                this.CreditoDisponible = decimal.Parse(ds.Tables[0].Rows[0]["CreditoDisponible"].ToString());

            }
            return ds;

        }
        /// <summary>
        /// Método para eliminar (Activar o inactivar) un proveedor del cátalogo de proveedores
        /// </summary>
        public void Eliminar()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("ClaveCliente", ClaveCliente);
                DataSet dsResultados = DB.executeSP("SpActivaInactivaCliente", parametros);
                if (dsResultados != null)
                {
                    StatusOP = int.Parse(dsResultados.Tables[0].Rows[0]["Result"].ToString());
                    Mensaje = dsResultados.Tables[0].Rows[0]["Mensaje"].ToString();
                }
            }
            catch (Exception ex)
            {
                StatusOP = -1;

                Mensaje = "";
                MensajeException = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
            }
        }
        /// <summary>
        /// Método que sirve para modificar un proveedor del cátalogo de proveedores
        /// </summary>
        public void Modificar()
        {
            try
            {
                Parametros parametros = new Parametros();
                obtenerParametros(parametros);
                DataSet dsResultados = DB.executeSP("SpModificarCliente", parametros);
                if (dsResultados != null)
                {
                    StatusOP = int.Parse(dsResultados.Tables[0].Rows[0]["Result"].ToString());
                    Mensaje = dsResultados.Tables[0].Rows[0]["Mensaje"].ToString();
                }
            }
            catch (Exception ex)
            {
                StatusOP = -1;
                Mensaje = "";
                MensajeException = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
            }
        }
        /// <summary>
        /// Método que sirve para guardar un nuevo proveedor en el cátalodo de proveedores
        /// </summary>
        public void Guardar()
        {
            try
            {
                Parametros parametros = new Parametros();
                obtenerParametros(parametros);
                DataSet dsResultados = DB.executeSP("SpInsertarCliente", parametros);
                if (dsResultados != null)
                {
                    StatusOP = int.Parse(dsResultados.Tables[0].Rows[0]["Result"].ToString());
                    Mensaje = dsResultados.Tables[0].Rows[0]["Mensaje"].ToString();
                }
            }
            catch (Exception ex)
            {
                StatusOP = -1;
                Mensaje = "";
                MensajeException = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
            }
        }
        #endregion
        public void obtenerParametros(Parametros parametros)
        {
            parametros.addParam("ClaveCliente", ClaveCliente);
            parametros.addParam("Nombre", Nombre);
            parametros.addParam("ApPaterno", ApPaterno);
            parametros.addParam("ApMaterno", ApMaterno);
            parametros.addParam("Direccion", Direccion);
            parametros.addParam("Telefono", Telefono);
            parametros.addParam("Correo", Correo);
            parametros.addParam("Contacto", Contacto);
            parametros.addParam("RFC", RFC);
            parametros.addParam("ClaveTipoCliente", ClaveTipoCliente);

        }
    }
}
