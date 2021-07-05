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
        public int ClaveTipoProducto { get; set; }
        public int ClaveCalidad { get; set; }
        public decimal Precio { get; set; }
        public decimal IVA { get; set; }
        public decimal GruesoCompra { get; set; }
        public decimal AnchoCompra { get; set; }
        public decimal LargoCompra { get; set; }
        public decimal GruesoVenta { get; set; }
        public decimal AnchoVenta { get; set; }
        public decimal LargoVenta { get; set; }
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
            parametros.addParam("ClaveTipoProducto", ClaveTipoProducto);
            parametros.addParam("ClaveCalidad", ClaveCalidad);
            parametros.addParam("Estatus", Status);
            DataSet ds = DB.executeSP("SpConsultarProductos", parametros);
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRowCollection drs = ds.Tables[0].Rows;
                NombreProducto = drs[0]["NombreProducto"].ToString();
                ClaveTipoProducto = int.Parse(drs[0]["ClaveTipoProducto"].ToString());
                ClaveCalidad = int.Parse(drs[0]["ClaveCalidad"].ToString());
                Precio = decimal.Parse(drs[0]["Precio"].ToString());
                IVA = decimal.Parse(drs[0]["IVA"].ToString());
                GruesoCompra = decimal.Parse(drs[0]["GruesoCompra"].ToString());
                AnchoCompra = decimal.Parse(drs[0]["AnchoCompra"].ToString());
                LargoCompra = decimal.Parse(drs[0]["LargoCompra"].ToString());
                GruesoVenta = decimal.Parse(drs[0]["GruesoVenta"].ToString());
                AnchoVenta = decimal.Parse(drs[0]["AnchoVenta"].ToString());
                LargoVenta = decimal.Parse(drs[0]["LargoVenta"].ToString());
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
            parametros.addParam("ClaveTipoProducto", ClaveTipoProducto);
            parametros.addParam("ClaveCalidad", ClaveCalidad);
            parametros.addParam("Precio", Precio);
            parametros.addParam("IVA", IVA);
            parametros.addParam("GruesoCompra", GruesoCompra);
            parametros.addParam("AnchoCompra", AnchoCompra);
            parametros.addParam("LargoCompra", LargoCompra);
            parametros.addParam("GruesoVenta", GruesoVenta);
            parametros.addParam("AnchoVenta", AnchoVenta);
            parametros.addParam("LargoVenta", LargoVenta);

        }
        #endregion
    }
}
