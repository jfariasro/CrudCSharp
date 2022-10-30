using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace appExamen2
{
    class Empleado
    {
        public int IDEMPLEADO { get; set; }
        public string NOMBRE { get; set; }
        public string CEDULA { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public float SUELDO { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public string CARGO { get; set; }

        SqlCommand comando = new SqlCommand();

        public string Grabar()
        {
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "INSERTAR_EMPLEADO";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@NOMBRE", NOMBRE);
                comando.Parameters.AddWithValue("@CEDULA", CEDULA);
                comando.Parameters.AddWithValue("@DIRECCION", DIRECCION);
                comando.Parameters.AddWithValue("@TELEFONO", TELEFONO);
                comando.Parameters.AddWithValue("@SUELDO", SUELDO);
                comando.Parameters.AddWithValue("@FECHA_INGRESO", FECHA_INGRESO);
                comando.Parameters.AddWithValue("@CARGO", CARGO);
                comando.Connection = Conexion.variableConex;
                Conexion.Conectar();
                comando.ExecuteReader();
                Conexion.Desconectar();
                return null;
            }
            catch (Exception ex)
            {
                Conexion.Desconectar();
                return ex.Message;
            }
        }

        public string Modificar()
        {
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "MODIFICAR_EMPLEADO";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@IDEMPLEADO", IDEMPLEADO);
                comando.Parameters.AddWithValue("@NOMBRE", NOMBRE);
                comando.Parameters.AddWithValue("@CEDULA", CEDULA);
                comando.Parameters.AddWithValue("@DIRECCION", DIRECCION);
                comando.Parameters.AddWithValue("@TELEFONO", TELEFONO);
                comando.Parameters.AddWithValue("@SUELDO", SUELDO);
                comando.Parameters.AddWithValue("@FECHA_INGRESO", FECHA_INGRESO);
                comando.Parameters.AddWithValue("@CARGO", CARGO);
                comando.Connection = Conexion.variableConex;
                Conexion.Conectar();
                comando.ExecuteReader();
                Conexion.Desconectar();
                return null;
            }
            catch (Exception ex)
            {
                Conexion.Desconectar();
                return ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ELIMINAR_EMPLEADO";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@IDEMPLEADO", IDEMPLEADO);
                comando.Connection = Conexion.variableConex;
                Conexion.Conectar();
                comando.ExecuteReader();
                Conexion.Desconectar();
                return null;
            }
            catch (Exception ex)
            {
                Conexion.Desconectar();
                return ex.Message;
            }
        }

        public DataSet Consultar()
        {
            try
            {
                var datos = new DataSet();
                var adaptador = new SqlDataAdapter();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CONSULTAR_EMPLEADO";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@NOMBRE", NOMBRE);
                comando.Connection = Conexion.variableConex;
                Conexion.Conectar();
                comando.ExecuteReader();
                Conexion.Desconectar();
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                return datos;
            }
            catch (Exception ex)
            {
                Conexion.Desconectar();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
