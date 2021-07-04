using PDV.Entities.Productos;
using System;
using System.Data;

namespace PDV.Bussiness.Productos
{
    public class Categorias
    {
        private readonly Categoria cat;
        public Categorias(Categoria cat)
        {
            this.cat = cat;
        }

        public bool Validar(out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(cat.Descripcion))
            {
                Mensaje = "Ingrese el nombre de la categoría.";
                return false;
            }

            return true;
        }

        public void Guadar(out string Mensaje, out Boolean Success)
        {
            Mensaje = "";
            Success = false;
            //if (Mensajes.MostrarConfirmacion("Nueva Categoría", "Desea ingresar la nueva categoría."))
            //{

            cat.InsertaCategoria();
            Mensaje = cat.Mensaje;
            Success = cat.StatusOP == 1;

        }

        public DataSet Consulta()
        {
            return cat.ConsultarCategorias();
        }
    }
}
