using PDV.Model;
using System;
using System.Data;

namespace PDV.Entities.Productos
{
    public class Clasificacion : Resultado
    {
        /// <summary>
        /// Propiedad ClaveClasificacion de la Clase Entities.Productos.Clasificaciones perteneciente a la tabla tblClasificaciones
        /// </summary>
        public int ClaveClasificacion { get; set; }
        /// <summary>
        /// Propiedad ClaveCategoria de la Clase Entities.Productos.Clasificaciones perteneciente a la tabla tblClasificaciones
        /// </summary>
        public int ClaveCategoria { get; set; }
        /// <summary>
        /// Propiedad Clasificacion de la Clase Entities.Productos.Clasificaciones perteneciente a la tabla tblClasificaciones
        /// </summary>
        public string NombreClasificacion { get; set; }
        /// <summary>
        /// Propiedad FEchaCreacion de la Clase Entities.Productos.Clasificaciones perteneciente a la tabla tblClasificaciones
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Propiedad FechaModificaion de la Clase Entities.Productos.Clasificaciones perteneciente a la tabla tblClasificaciones
        /// </summary>
        public DateTime FechaModificaion { get; set; }
        /// <summary>
        /// Propiedad Status de la Clase Entities.Productos.Clasificaciones perteneciente a la tabla tblClasificaciones
        /// </summary>
        public int Status { get; set; }


        public void Inserta()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("Clasificacion", NombreClasificacion);
                parametros.addParam("ClaveCategoria", ClaveCategoria);
                DataSet dsResultados = DB.executeSP("SpInsertaClasificacion", parametros);
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

        public void Consulta()
        {
            Parametros parametros = new Parametros();
            parametros.addParam("ClaveClasificacion", ClaveClasificacion);
            parametros.addParam("Clasificacion", NombreClasificacion);
            parametros.addParam("ClaveCategoria", ClaveCategoria);
            parametros.addParam("Estatus", Status);
            DataSet dsCategorias = DB.executeSP("SpConsultaClasificaciones", parametros);
            NombreClasificacion = dsCategorias.Tables[0].Rows[0]["Descripcion"].ToString();
            ClaveCategoria = int.Parse(dsCategorias.Tables[0].Rows[0]["intClaveClasificacion"].ToString());
        }

        public DataSet Consultar()
        {
            Parametros parametros = new Parametros();
            parametros.addParam("ClaveClasificacion", ClaveClasificacion);
            parametros.addParam("Clasificacion", NombreClasificacion);
            parametros.addParam("ClaveCategoria", ClaveCategoria);
            parametros.addParam("Estatus", Status);
            DataSet ds = DB.executeSP("SpConsultaClasificaciones", parametros);
            if (ds.Tables[0].Rows.Count == 1)
            {
                this.ClaveCategoria = int.Parse(ds.Tables[0].Rows[0]["ClaveClasificacion"].ToString());
                this.NombreClasificacion = ds.Tables[0].Rows[0]["Clasificacion"].ToString();
                this.ClaveCategoria = int.Parse(ds.Tables[0].Rows[0]["ClaveCategoria"].ToString());
            }
            return ds;

        }

        public void Actualizar()
        {
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("Clave", ClaveClasificacion);
                parametros.addParam("Descripcion", NombreClasificacion);
                DataSet dsResultados = DB.executeSP("SpModificaClasificacion", parametros);
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
                parametros.addParam("Clave", ClaveClasificacion);
                DataSet dsResultados = DB.executeSP("SpActivaInactivaClasificacion", parametros);
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
