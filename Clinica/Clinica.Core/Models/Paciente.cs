using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Core.Models
{
    public class Paciente
    {

        
        public string Id { get; set; }
        [StringLength(20)]
        [DisplayName("Nombre del Paciente")]
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string FechaDeNacimiento { get; set; }
        public string Sexo { get; set; }
        public string peso { get; set; }

        public Paciente()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }

    
}
