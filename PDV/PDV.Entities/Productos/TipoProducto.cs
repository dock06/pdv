using PDV.Model;
using System;
using System.Data;

namespace PDV.Entities.Productos
{
    public class TipoProducto : Resultado
    {
        public int ClaveTipoProducto { get; set; }
        public string NombreTipoProducto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificaion { get; set; }
        public int Status { get; set; }


        public void Guardar()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("NombreTipoProducto", NombreTipoProducto);
                DataSet dsResultados = DB.executeSP("SpInsertaTipoProducto", parametros);
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
        public DataSet Consultar()
        {
            Parametros parametros = new Parametros();
            parametros.addParam("ClaveTipoProducto", ClaveTipoProducto);
            parametros.addParam("NombreTipoProducto", NombreTipoProducto);
            parametros.addParam("Estatus", Status);
            DataSet ds = DB.executeSP("SpConsultaTipoProducto", parametros);

            if (ds.Tables[0].Rows.Count == 1)
            {
                NombreTipoProducto = ds.Tables[0].Rows[0]["NombreTipoProducto"].ToString();
            }

            return ds;
        }
        public void Actualizar()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("ClaveTipoProducto", ClaveTipoProducto);
                parametros.addParam("NombreTipoProducto", NombreTipoProducto);
                DataSet dsResultados = DB.executeSP("SpModificarTipoProducto", parametros);
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
                parametros.addParam("ClaveTipoProducto", ClaveTipoProducto);
                DataSet dsResultados = DB.executeSP("SpActivaInactivaTipoProducto", parametros);
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
    }
}
