using PDV.Entities.Productos;
using System.Data;

namespace PDV.Bussiness.Productos
{
    public class Productos
    {
        public readonly Entities.Productos.Producto producto;

        public Productos(Entities.Productos.Producto _productos)
        {
            producto = _productos;
        }
        public DataSet Consultar()
        {
            return producto.Consultar();
        }
        public void Guardar()
        {
            producto.Guardar();
        }
        public void Modificar()
        {
            producto.Modificar();
        }
        public void Eliminar()
        {
            producto.Eliminar();
        }
    }
}
