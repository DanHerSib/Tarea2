using System;

namespace Entity
{
    public class EmpleadoEntity
    {
        public int? IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int? Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }

        //Propiedades Tipo de identificacion
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
    }
}
