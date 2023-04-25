using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace negocio
{
    internal class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        

        //Da acceso a lector
        public SqlDataReader Lector
        {
            get { return lector; }
        }


        //Constructor, inicia conexion y comando
        public AccesoDatos() 
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
        }

        //Envia consulta a la BD
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }


        //Almacena la devolucion de la BD
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Cierra conexion
        public void cerrarConexion()
        {
            if(lector != null)
                lector.Close();
            conexion.Close();
        }

        public void setearParametros(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }

        public void insertarDatos()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
