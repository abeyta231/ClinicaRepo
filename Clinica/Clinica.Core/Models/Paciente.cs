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
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Peso { get; set; }
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string CorreoElectronico { get; set; }
        public string EstudioSolicitado { get; set; }
        public string MedicoTratante { get; set; }
        public string FUM { get; set; }
        public string FechaActual
        {
            get
            {
                return DateTime.Now.ToString("dd/MM/yyyy");
            }
            set {FechaActual = value; }
        }
      





        public Paciente()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }

    
}
