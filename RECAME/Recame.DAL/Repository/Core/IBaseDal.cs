using Recame.DAL.DataContracts;
using Recame.DAL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL.Repository.Core
{
    
    public interface IBaseDal: IDisposable
    {
        Tentity Find<Tentity>(params object[] keyValues) where Tentity : ModelBase;
        void Add<TEntity>(TEntity entity) where TEntity : ModelBase;
        void SetValues(object entity, object dbEntity);
        void Save<TEntity>(TEntity entity) where TEntity : ModelBase;
        void Remove<TEntity>(TEntity entity) where TEntity : ModelBase;
        void Attach<TEntity>(TEntity entity) where TEntity : ModelBase;
        void Reload<TEntity>(TEntity entity) where TEntity : ModelBase;

        bool HasChanges();
        int SaveChanges();

        void EnsureTransaction();
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();

    }
}
