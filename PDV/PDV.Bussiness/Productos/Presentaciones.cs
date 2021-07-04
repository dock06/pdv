using PDV.Entities.Productos;
using System.Data;

namespace PDV.Bussiness.Productos
{
    public class Presentaciones
    {
        private readonly Entities.Productos.Presentacion presentacion;
        public Presentaciones(Entities.Productos.Presentacion pre)
        {
            this.presentacion = pre;
        }
        #region Metodos
        public bool validar()
        {
            if (string.IsNullOrEmpty(this.presentacion.NombrePresentacion))
            {
                presentacion.Mensaje = "Ingrese el nombre de la presención";
                return false;
            }
            if(presentacion.ClaveClasificacion == 0)
            {
                presentacion.Mensaje = "Seleccione el tipo de clasificación";
                return false;
            }
            return true;
        }
        public void Guardar()
        {
            presentacion.Insertar();
        }

        public DataTable Consultar()
        {
           return presentacion.Consultar();
        }
        public void Eliminar()
        {
            presentacion.Eliminar();
        }
        public void Actualizar()
        {
            presentacion.Actualizar();
        }
        #endregion
    }
}
