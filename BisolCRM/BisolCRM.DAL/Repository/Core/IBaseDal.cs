using BisolCRM.DAL.DataContracts;
using BisolCRM.DAL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Repository.Core
{
    public interface IBaseDal: IDisposable
    {
        Tentity Find<Tentity>(params object[] keyValues) where Tentity : ModelBase;
        //TEntity SingleOrDefault<TEntity>(FilterBase filter) where TEntity : ModelBase;
        //TEntity FirstOrDefault<TEntity>(FilterBase filter) where TEntity : ModelBase;
        //List<TEntity> GetListByFilter<TEntity>(FilterBase filter) where TEntity : ModelBase;
        //bool Any<TEntity>(FilterBase filter) where TEntity : ModelBase;
        //int Count<TEntity>(FilterBase filter) where TEntity : ModelBase;
        void Add<TEntity>(TEntity entity) where TEntity : ModelBase;
        //void BulkInsert<TEntity>(IEnumerable<TEntity> entities) where TEntity : ModelBase;
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

        //DateTimeOffset GetDBSysDate();

        ITAWDBRESCONTRACTCALCDal TAWDBRESCONTRACTCALCDal { get; set; }

        

    }
}
