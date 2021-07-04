using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace PDV.Model
{
    public class DB
    {
        private static string DBConnect = "";

        public DB()
        {
            DBConnect = ConfigurationManager.AppSettings["DB_PDV"].ToString();
        }

        public static void testConecction()
        {
            DBConnect = ConfigurationManager.ConnectionStrings["DB_PDV"].ConnectionString;
            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = DBConnect;
            conexion.Open();
        }

        public static DataSet executeSP(string procedimiento, Parametros parametros)
        {
            DBConnect = ConfigurationManager.ConnectionStrings["DB_PDV"].ConnectionString;
            DataSet dsResultados = new DataSet();
            using (MySqlConnection cnn = new MySqlConnection(DBConnect))
            {
                using (MySqlCommand cmd = new MySqlCommand(procedimiento, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cnn.Open();
                    if (parametros != null)
                    {
                        if (parametros.Lista_Parametro.Count > 0)
                        {
                            foreach (Parametro pars in parametros.Lista_Parametro)
                            {
                                cmd.Parameters.Add(new MySqlParameter(pars.Key, pars.Value));
                                cmd.Parameters[pars.Key].Direction = System.Data.ParameterDirection.Input;
                            }
                        }
                    }
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dsResultados);
                    cnn.Close();
                }
            }
            return dsResultados;
        }
    }

    public class Parametros
    {
        public List<Parametro> Lista_Parametro = new List<Parametro>();

        public void addParam(string nombre, object valor)
        {
            Lista_Parametro.Add(new Parametro { Key = nombre, Value = valor });
        }
    }

    public class Parametro
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
