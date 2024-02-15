using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraCapas.Infraestructura
{
    public  class Conexion
    {
        private SqlConnection _conexion;
        private Exception e = null;
        public Conexion()
        {
            _conexion = new SqlConnection("Server=LAPTOP-RGCMB45P\\SQLEXPRESS;Initial catalog=Matricula;Integrated Security=true");
        }
        public SqlConnection AbrirConexion ()
        {
            if (_conexion.State == System.Data.ConnectionState.Closed)
            {
                return _conexion;
            }
            else 
            {
                throw new Exception("Error de conexion a los datos de Estudiante -- " + e.Message);
            }
        }
        public void CerrarConexion()
        {
            _conexion.Close();
        }
    }
}
