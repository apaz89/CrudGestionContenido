using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace CrudGestionContenido.Domain.Services
{
    public interface IWriteOnlyRepository
    {
        T Create<T>(T itemToCreate) where T : class, IEntity;
        T Update<T>(T itemToUpdate) where T : class, IEntity;
        void Archive<T>(T itemToArchive);
    }
}
