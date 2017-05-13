using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrudGestionContenido.Web.Models
{
    public class DepartamentoModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre ")]
        [Required(ErrorMessage = "Required Field")]
        public string Nombre { get; set; }
    }
}