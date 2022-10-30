using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using appExamen2.Properties;
using System.Configuration;

namespace appExamen2
{
    class Conexion
    {
        public static SqlConnection variableConex = new SqlConnection("Data Source=LAPTOP-LFOM23KG\\SQLEXPRESS;Initial Catalog=EXAMEN_POO_2;Integrated Security=True");

        public static void Conectar()
        {
            try
            {
                variableConex.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static void Desconectar()
        {
            try
            {
                variableConex.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
