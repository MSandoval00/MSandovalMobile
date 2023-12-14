using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSandovalMobile.Models
{
    public class Alumno
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Escuela Escuela { get; set; }
        [ForeignKey("EscuelaForeignKey")]
        public int IdEscuela { get; set; }
    }
}
