using System.Data;

namespace PDV.Bussiness.Clientes
{
    /// <summary>
    /// Clase Proveedores ejecuta los metodos de la clase proveedor de la capa de entidades
    /// </summary>
    public class Clientes
    {
        public readonly Entities.Clientes.Cliente cliente;
        public Clientes(Entities.Clientes.Cliente _Cliente)
        {
            cliente = _Cliente;
        }
        /// <summary>
        /// Ejecuta el Método Consultar de la clase Entities.Proveedor
        /// </summary>
        /// <returns></returns>
        public DataSet Consulta()
        {
            return cliente.Consultar();
        }
        /// <summary>
        /// Ejecuta el Método Eliminar de la clase Entities.Proveedor
        /// </summary>
        public void Eliminar()
        {
            cliente.Eliminar();
        }
        /// <summary>
        /// Ejecuta el Método Modificar de la clase Entities.Proveedor
        /// </summary>
        public void Modificar()
        {
            cliente.Modificar();
        }
        /// <summary>
        /// Ejecuta el Método Guardar de la clase Entities.Proveedor
        /// </summary>
        public void Guardar()
        {
            cliente.Guardar();
        }
    }

}
