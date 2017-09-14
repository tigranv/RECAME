using Recame.Common.Constants;
using Recame.DAL.DataContracts;
using Recame.DAL.DataContracts.Filters;
using Recame.DAL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL.Repository.Core
{
    public class BaseDal : IBaseDal, IQueryBuilder
    {
        private RecameDBEntities _db;

        private readonly bool _contextCreatedHere;

        protected DbContextTransaction Transaction { get; private set; }

        public BaseDal(RecameDBEntities db = null, bool isReadOnly = false)
        {
            if (null == db)
            {
                if (isReadOnly)
                    db = new RecameDBEntities(Constants.Others.ReadOnlyDbConnectionName, true);
                else
                    db = new RecameDBEntities();
                _contextCreatedHere = true;
            }

            _db = db;
        }

        protected internal RecameDBEntities db
        {
            get { return _db; }
        }

        public TEntity Find<TEntity>(params object[] keyValues) where TEntity : ModelBase
        {
            bool oldValue = db.Configuration.AutoDetectChangesEnabled;
            db.Configuration.AutoDetectChangesEnabled = false;
            try
            {
                return db.Set<TEntity>().Find(keyValues);
            }
            finally
            {
                db.Configuration.AutoDetectChangesEnabled = oldValue;
            }
        }

        public virtual TEntity SingleOrDefault<TEntity>(FilterBase filter) where TEntity : ModelBase
        {
            IQueryBuilder dal = this; //GetDalByFilter(filter.GetType());

            var query = dal.PrepareQuery<TEntity>(filter);
            if (null != query)
                return query.SingleOrDefault();
            return null;
        }

        public virtual TEntity FirstOrDefault<TEntity>(FilterBase filter) where TEntity : ModelBase
        {
            IQueryBuilder dal = this; //GetDalByFilter(filter.GetType());
            {
                var query = dal.PrepareQuery<TEntity>(filter);
                if (null != query)
                    return query.FirstOrDefault();
            }

            return null;
        }

        public virtual List<TEntity> GetListByFilter<TEntity>(FilterBase filter) where TEntity : ModelBase
        {
            IQueryBuilder dal = this; //GetDalByFilter(filter.GetType());
            if (null != dal)
            {
                var query = dal.PrepareQuery<TEntity>(filter);
                if (null != query)
                    return query.ToList();
            }

            return new List<TEntity>();
        }

        public virtual bool Any<TEntity>(FilterBase filter) where TEntity : ModelBase
        {
            IQueryBuilder dal = this; //GetDalByFilter(filter.GetType());
                                      //            if (null != dal)
                                      //            {
            var query = dal.PrepareQuery<TEntity>(filter);
            if (null != query)
                return query.Any();
            //            }

            return false;
        }

        public virtual int Count<TEntity>(FilterBase filter) where TEntity : ModelBase
        {
            IQueryBuilder dal = this; //GetDalByFilter(filter.GetType());
            var query = dal.PrepareQuery<TEntity>(filter);
            if (null != query)
                return query.Count();
            return 0;
        }

        public virtual IQueryable<TEntity> PrepareQuery<TEntity>(FilterBase filter) where TEntity : ModelBase
        {
            IQueryable<TEntity> query = ApplyAsNoTracking(db.Set<TEntity>(), filter);
            query = ApplyIncludes(query, filter);
            return filter.FilterObjects(query).Cast<TEntity>();
        }

        public List<TEntity> GetAll<TEntity>() where TEntity : ModelBase
        {
            return db.Set<TEntity>().AsNoTracking().ToList();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : ModelBase
        {
            db.Set<TEntity>().Add(entity);
        }

        public void SetValues(object entity, object dbEntity)
        {
            db.SetValues(entity, dbEntity);
        }

        public void Save<TEntity>(TEntity entity) where TEntity : ModelBase
        {
            if (null == entity)
                return;

            var dbEntry = db.Entry<TEntity>(entity);
            if (null == dbEntry || dbEntry.State == System.Data.Entity.EntityState.Detached)
                Add(entity);
            else if (!ReferenceEquals(dbEntry.Entity, entity))
                SetValues(entity, dbEntry.Entity);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : ModelBase
        {
            db.Set<TEntity>().Remove(entity);
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : ModelBase
        {
            db.Set<TEntity>().Attach(entity);
        }

        public void Reload<TEntity>(TEntity entity) where TEntity : ModelBase
        {
            db.Reload(entity);
        }

        public bool HasChanges()
        {
            return db.HasChanges();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        #region "Transaction"

        public void EnsureTransaction()
        {
            if (Transaction != null)
                return;

            BeginTransaction();
        }

        public void BeginTransaction()
        {
            if (Transaction != null)
                throw new InvalidOperationException(Constants.Errors.TransactionAlreadyOpen);

            Transaction = db.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            if (Transaction == null)
                return;

            Transaction.Rollback();
            Transaction = null;
        }

        public void CommitTransaction()
        {
            if (Transaction == null)
                return;

            Transaction.Commit();
            Transaction = null;
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Transaction != null)
                {
                    Transaction.Dispose();
                    Transaction = null;
                }

                if (_db != null)
                {
                    if (_contextCreatedHere)
                        db.Dispose();
                    _db = null;
                }
            }
        }

        public virtual DbQuery<TEntity> ApplyAsNoTracking<TEntity>(DbQuery<TEntity> query, FilterBase filter)
        {
            if (filter.AsNoTracking)
                return query.AsNoTracking();

            return query;
        }

        public IQueryable<TEntity> ApplyIncludes<TEntity>(IQueryable<TEntity> query, FilterBase filter)
        {
            if (filter.IncludePaths != null)
            {
                foreach (var path in filter.IncludePaths)
                    query = query.Include(path);
            }

            return query;

        }

        private string GetTableName<TEntity>() where TEntity : ModelBase
        {
            var sql = db.Set<TEntity>().ToString();
            var regex = new System.Text.RegularExpressions.Regex(@"FROM \[dbo\]\.\[(?<table>.*)\] AS");
            var match = regex.Match(sql);

            return match.Groups["table"].Value;
        }
    }
}
