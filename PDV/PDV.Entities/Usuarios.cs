using PDV.Model;
using System.Data;

namespace PDV.Entities
{
    public class Usuarios
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string nombreUsuario { get; set; }
        public void Login()
        {
            Parametros parametros = new Parametros();
            parametros.addParam("nombreUsuario", usuario);
            parametros.addParam("Contrasena", password);
            DataSet dsLogin = DB.executeSP("spLogin", parametros);
            if (dsLogin != null)
            {
                nombreUsuario = dsLogin.Tables[0].Rows[0]["usuario"].ToString();
            }
            
        }
    }
}
