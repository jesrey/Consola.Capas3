using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraCapas.Infraestructura.Entidades
{
    public class EstudianteEntity
    {
        public int id_Estudiante { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public decimal  Telefono { get; set; }
        public string  Correo { get; set; }
    }
}
