using System.Data;

namespace PDV.Bussiness.Proveedores
{
    /// <summary>
    /// Clase Proveedores ejecuta los metodos de la clase proveedor de la capa de entidades
    /// </summary>
    public class Proveedores
    {
        public readonly Entities.Proveedores.Proveedor proveedor;
        public Proveedores(Entities.Proveedores.Proveedor _Proveedor)
        {
            proveedor = _Proveedor;
        }
        /// <summary>
        /// Ejecuta el Método Consultar de la clase Entities.Proveedor
        /// </summary>
        /// <returns></returns>
        public DataSet Consulta()
        {
            return proveedor.Consultar();
        }
        /// <summary>
        /// Ejecuta el Método Eliminar de la clase Entities.Proveedor
        /// </summary>
        public void Eliminar()
        {
            proveedor.Eliminar();
        }
        /// <summary>
        /// Ejecuta el Método Modificar de la clase Entities.Proveedor
        /// </summary>
        public void Modificar()
        {
            proveedor.Modificar();
        }
        /// <summary>
        /// Ejecuta el Método Guardar de la clase Entities.Proveedor
        /// </summary>
        public void Guardar()
        {
            proveedor.Guardar();
        }
    }

}
