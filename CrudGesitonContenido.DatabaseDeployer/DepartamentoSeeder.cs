using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDatabaseDeployer;
using FizzWare.NBuilder;
using CrudGestionContenido.Domain;
using NHibernate;


namespace CrudGesitonContenido.DatabaseDeployer
{
    public class DepartamentoSeeder : IDataSeeder
    {
        private readonly ISession _session;

        public DepartamentoSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            IList<Departamento> accountList = Builder<Departamento>.CreateListOfSize(5).Build();
            foreach (Departamento account in accountList)
            {
                _session.Save(account);
            }
        }
    }
}
