using System.Data;

namespace PDV.Bussiness.Productos
{
    public class Calidad
    {
        public readonly Bussiness.Productos.Calidad clasificacion;

        public Calidad(Calidad _clasificacion)
        {
            clasificacion = _clasificacion;
        }

        public DataSet Consultar()
        {
            return clasificacion.Consultar();
        }
        public void Guardar()
        {
            clasificacion.Guardar();
        }
        public void Modificar()
        {
            clasificacion.Modificar();
        }
        public void Eliminar()
        {
            clasificacion.Eliminar();
        }
    }
}
