using PDV.Model;
using System;
using System.Data;

namespace PDV.Entities.Productos
{
    public class Presentacion : Resultado
    {
        #region Propiedades
        public int ClavePresentacion { get; set; }
        public string NombrePresentacion { get; set; }
        public int ClaveClasificacion { get; set; }
        public DateTime FechaCrecaion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int Estatus { get; set; }
        #endregion

        #region Metodos
        public DataTable Consultar()
        {
            DataTable dtDatos = null;
            try
            {
                Parametros parametros = new Parametros();
                parametros.addParam("ClavePresentacion", ClavePresentacion);
                parametros.addParam("Presentacion", NombrePresentacion);
                parametros.addParam("ClaveClasificacion", ClaveClasificacion);
                parametros.addParam("Estatus", Estatus);
                dtDatos = DB.executeSP("SpConsultaPresentaciones", parametros).Tables[0];
                if (dtDatos.Rows.Count == 1)
                {
                    this.NombrePresentacion = dtDatos.Rows[0][1].ToString();
                    this.ClaveClasificacion = int.Parse(dtDatos.Rows[0][2].ToString());
                }
            }
            catch (Exception ex)
            {
                StatusOP = -1;

                Mensaje = "";
                MensajeException = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
            }
            return dtDatos;
        }
        public void Insertar()
        {
            try
            {
                DataSet dsResultados = new DataSet();
                Parametros parametros = new Parametros();
                parametros.addParam("Presentacion", NombrePresentacion);
                parametros.addParam("ClaveClasificacion", ClaveClasificacion);
                dsResultados = DB.executeSP("SpInsertaPresentacion", parametros);

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
        public void Actualizar()
        {
            try
            {
                DataSet dsResultados = new DataSet();
                Parametros parametros = new Parametros();
                parametros.addParam("Presentacion", NombrePresentacion);
                parametros.addParam("ClavePresentacion", ClavePresentacion);
                parametros.addParam("ClaveClasificacion", ClaveClasificacion);
                dsResultados = DB.executeSP("SpModificarPresentacion", parametros);
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
                parametros.addParam("Clave", ClavePresentacion);
                DataSet dsResultados = DB.executeSP("SpInactivaActivaPresentacion", parametros);
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
    }
}
