using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudGestionContenido.Domain
{
    public class Departamento: IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual IList<Empleado> Empleados { get; set; }
    }
}
