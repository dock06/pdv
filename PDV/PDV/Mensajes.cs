using System.Windows.Forms;

namespace PDV
{
    public class Mensajes
    {
        public static void MostrarNotificacion(string Titulo, string Mensaje)
        {
            MessageBox.Show(Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool MostrarConfirmacion(string Titulo, string Mensaje)
        {
            return MessageBox.Show(Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
        }
        public static void MostrarAdvertencia(string Titulo, string Mensaje)
        {
            MessageBox.Show(Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MostrarError(string Titulo, string Mensaje)
        {
            MessageBox.Show(Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
