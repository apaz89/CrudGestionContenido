    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using CrudGestionContenido.Domain;

namespace CrudGestionContenido.Data.AutoMappingOverride
{
    internal class DepartamentoOverride : IAutoMappingOverride<Departamento>
    {
        public void Override(AutoMapping<Departamento> mapping)
        {
            /* mapping.HasMany(x => x.Referrals)
                 .Inverse()
                 .Access.CamelCaseField(Prefix.Underscore);*/
        }
    }
}
