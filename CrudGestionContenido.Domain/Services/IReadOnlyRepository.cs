using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace CrudGestionContenido.Domain.Services
{
    public interface IReadOnlyRepository
    {
        T First<T>(Expression<Func<T, bool>> query) where T : class, IEntity;
        T GetById<T>(long id) where T : class, IEntity;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : class, IEntity;
        IQueryable<T> GetAll<T>() where T : class, IEntity;
    }
}
