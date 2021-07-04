using PDV.Model;
using System;
using System.Data;

namespace PDV.Entities.Productos
{
    public class Producto : Resultado
    {
        #region Propiedades
        public int ClaveProducto { get; set; }
        public string NombreProducto { get; set; }
        public int ClaveCategoria { get; set; }
        public int ClaveClasificacion { get; set; }
        public int ClavePresentacion { get; set; }
        public decimal Precio { get; set; }
        public decimal IVA { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int Status { get; set; }
        #endregion
        #region Métodos
        public DataSet Consultar()
        {
            Parametros parametros = new Parametros();
            parametros.addParam("ClaveProducto", ClaveProducto);
            parametros.addParam("NombreProducto", NombreProducto);
            parametros.addParam("ClaveCategoria", ClaveCategoria);
            parametros.addParam("ClaveClasificacion", ClaveClasificacion);
            parametros.addParam("ClavePresentacion", ClavePresentacion);
            parametros.addParam("Estatus", Status);
            DataSet ds = DB.executeSP("SpConsultarProductos", parametros);
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRowCollection drs = ds.Tables[0].Rows;
                NombreProducto = drs[0][1].ToString();
                ClaveCategoria = int.Parse(drs[0][9].ToString());
                ClaveClasificacion = int.Parse(drs[0][10].ToString());
                ClavePresentacion = int.Parse(drs[0][11].ToString());
                Precio = decimal.Parse(drs[0][5].ToString());
                IVA = decimal.Parse(drs[0][6].ToString());
            }
            return ds;
        }
        public void Guardar()
        {
            try
            {
                Parametros parametros = new Parametros();
                ObtenerParametros(parametros);
                DataSet dsResultados = DB.executeSP("SpInsertarProducto", parametros);
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
        public void Modificar()
        {
            try
            {
                Parametros parametros = new Parametros();
                ObtenerParametros(parametros);
                DataSet dsResultados = DB.executeSP("SpModificarProducto", parametros);
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
        public void Eliminar()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("ClaveProducto", ClaveProducto);
                DataSet dsResultados = DB.executeSP("SpActivaInactivaProducto", parametros);
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
        public void ObtenerParametros(Parametros parametros)
        {
            parametros.addParam("ClaveProducto", ClaveProducto);
            parametros.addParam("NombreProducto", NombreProducto);
            parametros.addParam("ClaveCategoria", ClaveCategoria);
            parametros.addParam("ClaveClasificacion", ClaveClasificacion);
            parametros.addParam("ClavePresentacion", ClavePresentacion);
            parametros.addParam("Precio", Precio);
            parametros.addParam("IVA", IVA);
        }
        #endregion
    }
}
