using PDV.Model;
using System;
using System.Data;

namespace PDV.Entities.Productos
{
    public class Categoria : Resultado
    {
        public int ClaveCategoria { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificaion { get; set; }
        public int Status { get; set; }


        public void InsertaCategoria()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("Descripcion", Descripcion);
                DataSet dsResultados = DB.executeSP("SpInsertCategoria", parametros);
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

        public void ConsultaCategoria()
        {
            Parametros parametros = new Parametros();
            parametros.addParam("Clave", ClaveCategoria);
            DataSet dsCategorias = DB.executeSP("spConsultaCategoria", parametros);
            Descripcion = dsCategorias.Tables[0].Rows[0]["Descripcion"].ToString();
        }

        public DataSet ConsultarCategorias()
        {
            Parametros parametros = new Parametros();
            parametros.addParam("Descripcion", Descripcion);
            parametros.addParam("Estatus", Status);
            DataSet ds = DB.executeSP("SpConsultaCategorias", parametros);

            if (ds.Tables[0].Rows.Count == 1)
            {
                Descripcion = ds.Tables[0].Rows[0]["Descripcion"].ToString();
            }

            return ds;
        }

        public void ActualizarCategoria()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("Clave", ClaveCategoria);
                parametros.addParam("Descripcion", Descripcion);
                DataSet dsResultados = DB.executeSP("SpModificarCategoria", parametros);
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

        public void EliminarCategoria()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("Clave", ClaveCategoria);
                DataSet dsResultados = DB.executeSP("SpActivaInactivaCategoria", parametros);
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
