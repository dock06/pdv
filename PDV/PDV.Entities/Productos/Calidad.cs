using PDV.Model;
using System;
using System.Data;

namespace PDV.Entities.Productos
{
    public class Calidad : Resultado
    {
        /// <summary>
        /// Propiedad ClaveClasificacion de la Clase Entities.Productos.Calidad perteneciente a la tabla tblCalidad
        /// </summary>
        public int ClaveCalidad { get; set; }
        /// <summary>
        /// Propiedad Calidad de la Clase Entities.Productos.Calidad perteneciente a la tabla tblCalidad
        /// </summary>
        public string NombreCalidad { get; set; }
        /// <summary>
        /// Propiedad FEchaCreacion de la Clase Entities.Productos.Calidad perteneciente a la tabla tblCalidad
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Propiedad FechaModificaion de la Clase Entities.Productos.Calidad perteneciente a la tabla tblCalidad
        /// </summary>
        public DateTime FechaModificaion { get; set; }
        /// <summary>
        /// Propiedad Status de la Clase Entities.Productos.Calidad perteneciente a la tabla tblCalidad
        /// </summary>
        public int Status { get; set; }
        public void Inserta()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("Calidad", NombreCalidad);
                DataSet dsResultados = DB.executeSP("SpInsertaCalidad", parametros);
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
            parametros.addParam("ClaveCalidad", ClaveCalidad);
            parametros.addParam("Calidad", NombreCalidad);
            parametros.addParam("Estatus", Status);
            DataSet ds = DB.executeSP("SpConsultaCalidad", parametros);
            if (ds.Tables[0].Rows.Count == 1)
            {
                this.ClaveCalidad = int.Parse(ds.Tables[0].Rows[0]["ClaveCalidad"].ToString());
                this.NombreCalidad = ds.Tables[0].Rows[0]["Calidad"].ToString();
            }
            return ds;

        }
        public void Actualizar()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("ClaveCalidad", ClaveCalidad);
                parametros.addParam("Calidad", NombreCalidad);
                DataSet dsResultados = DB.executeSP("SpModificaCalidad", parametros);
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
                parametros.addParam("ClaveCalidad", ClaveCalidad);
                DataSet dsResultados = DB.executeSP("SpActivaInactivaCalidad", parametros);
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
