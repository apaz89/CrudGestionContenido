using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using CrudGestionContenido.Domain;
using CrudGestionContenido.Domain.Services;

namespace CrudGestionContenido.Data
{
    public class WriteOnlyRepository : IWriteOnlyRepository
    {
        private readonly ISession _session;

        public WriteOnlyRepository(ISession session)
        {
            _session = session;
        }

        public T Create<T>(T itemToCreate) where T : class, IEntity
        {
            _session.Save(itemToCreate);
            return itemToCreate;
        }

        public T Update<T>(T itemToUpdate) where T : class, IEntity
        {
            _session.Update(itemToUpdate);
            _session.Flush();
            return itemToUpdate;
        }

        public void Archive<T>(T itemToArchive)
        {
            throw new NotImplementedException();
        }

    }
}
