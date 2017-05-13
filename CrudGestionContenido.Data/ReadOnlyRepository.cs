using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using CrudGestionContenido.Domain;
using CrudGestionContenido.Domain.Services;

namespace CrudGestionContenido.Data
{
   public class ReadOnlyRepository : IReadOnlyRepository
    {
        private readonly ISession _session;

        public ReadOnlyRepository(ISession session)
        {
            _session = session;
        }

        public T First<T>(Expression<Func<T, bool>> query) where T : class, IEntity
        {
            T firstOrDefault = _session.Query<T>().FirstOrDefault(query);
            return firstOrDefault;
        }

        public T GetById<T>(long id) where T : class, IEntity
        {
            var item = _session.Get<T>(id);
            return item;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : class, IEntity
        {
            return _session.Query<T>().Where(expression);
        }

        public IQueryable<T> GetAll<T>() where T : class, IEntity
        {
            return _session.Query<T>();
        }

    }
}