using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CrudGestionContenido.Web.Models
{
    public class EmpleadoModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre ")]
        [Required(ErrorMessage = "Required Field")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido ")]
        [Required(ErrorMessage = "Required Field")]
        public string Apellido { get; set; }

        [Display(Name = "FechaNacimiento ")]
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Sueldo ")]
        [Required(ErrorMessage = "Required Field")]
        public float Sueldo { get; set; }


        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Required Field")]
        public int Departamento_id { get; set; }
        public IEnumerable<SelectListItem> Departamentos { set; get; }

        public string Departamento_Name { get; set; }
    }
}