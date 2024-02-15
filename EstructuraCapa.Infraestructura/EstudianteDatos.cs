using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraCapas.Infraestructura
{
    public class EstudianteDatos
    {
        private Conexion _conexion;
        private SqlDataReader _reader;
        private SqlCommand _command;
        private DataTable _dataTable;
        public EstudianteDatos()
        {
            _conexion = new Conexion();
            //_reader = new SqlDataReader();
            _command = new SqlCommand();
            _dataTable = new DataTable();
        }
        public DataTable crudEstudiantes(int operacion, Entidades.EstudianteEntity estudiante) 
        {
            try
            {
                //Abrir conexion
                _command.Connection = _conexion.AbrirConexion();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "CrudEstudiante";

                //Enviar Parametros al SP

                _command.Parameters.AddWithValue("@param_IdOperacion", operacion);
                _command.Parameters.AddWithValue("@param_id", estudiante.id_Estudiante);
                _command.Parameters.AddWithValue("@param_nombre", estudiante.Nombre);
                _command.Parameters.AddWithValue("@param_direccion", estudiante.Direccion);
                _command.Parameters.AddWithValue("@param_telefono", estudiante.Telefono);
                _command.Parameters.AddWithValue("@param_correo", estudiante.Correo);
                
                //Ejecuta el SP

                _reader = _command.ExecuteReader();
                _dataTable.Load(_reader);
                //Devolver la tabla
                
                return _dataTable;
            }
            catch (Exception e)
            {
                throw new Exception("Error de conexion a los datos de Estudiante -- " + e.Message);
            }
            finally
            { 
                _command.Dispose();
                _conexion.CerrarConexion();
            }
        }
    }
}
