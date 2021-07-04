using System.Data;

namespace PDV.Bussiness.Productos
{
    public class Clasificaciones
    {
        public readonly Bussiness.Productos.Clasificaciones clasificacion;

        public Clasificaciones(Clasificaciones _clasificacion)
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
