using System.Data;

namespace PDV.Bussiness.Productos
{
    public class TipoProducto
    {
        private readonly Entities.Productos.TipoProducto tipoProducto;
        public TipoProducto(Entities.Productos.TipoProducto _tipoProducto)
        {
            this.tipoProducto = _tipoProducto;
        }

        public void Guadar()
        {
            tipoProducto.Guardar();
        }
        public void Eliminar()
        {
            tipoProducto.Eliminar();
        }
        public DataSet Consulta()
        {
            return tipoProducto.Consultar();
        }
    }
}
