using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudGestionContenido.Domain
{
    public class Empleado:IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string FechaNacimiento { get; set; }
        public virtual float Sueldo { get; set; }
        public virtual IList<Departamento> Departamentos { get; set; }
               
    }
}
