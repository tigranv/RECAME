using BisolCRM.Common.Helpers;
using BisolCRM.DAL.Interfaces;
using BisolCRM.DAL.Repository.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL
{
    public partial class BisolDBEntities : IBisolDBEntities
    {
        private static readonly string UpdateVersionPropName = CommonUtils.GetPropertyPath<IObjectVersion>(x => x.UpdateVersion);
        private readonly bool isReadOnly;
        public BisolDBEntities(string connectionStr, bool isReadOnly = false)
            : base("name=" + connectionStr)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.isReadOnly = isReadOnly;
            if (isReadOnly)
                this.Database.CommandTimeout = 120;
        }
        public BisolDBEntities(string connectionStr)
                : base(connectionStr)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

        }
        public void SetValues(object from, object to)
        {
            Entry(to).CurrentValues.SetValues(from);
            if (null != UpdateVersionPropName && from is IObjectVersion && to is IObjectVersion && Entry(to).State != EntityState.Added && null != Entry(to).OriginalValues && null != ((IObjectVersion)from).UpdateVersion)
            {
                Entry(to).OriginalValues[UpdateVersionPropName] = ((IObjectVersion)from).UpdateVersion;
            }

        }

        public void LoadReference<TEnt, TFunk>(TEnt entity, Expression<Func<TEnt, TFunk>> exp) where TEnt : class where TFunk : class
        {
            Entry<TEnt>(entity).Reference(exp).Load();
        }

        // public DbSet<ClientSportsbookProfile> ClientSportsbookProfiles { get; set; }

        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
        }

        public void Reload(object entity)
        {
            Entry(entity).Reload();
        }

        public EntityState GetState(object entity)
        {
            return Entry(entity).State;
        }
        public void SetState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }
        public TEntity Find<TEntity>(params object[] keyValues) where TEntity : class

        {
            return Set<TEntity>().Find(keyValues);
        }


        public bool HasChanges()
        {
            return ChangeTracker.HasChanges();
        }

        public IEnumerable<DbEntityEntry> GetChangedEntries()
        {
            return ChangeTracker.Entries();
        }

        public TEntity Find<TEntity, TKey>(params object[] keyValues)
            where TEntity : class
            where TKey : struct, IComparable, IEquatable<TKey>
        {
            return Find<TEntity>(keyValues);
        }


        public DbSet<TEntity> Set<TEntity, TKey>()
            where TEntity : class
            where TKey : struct, IComparable, IEquatable<TKey>
        {
            return Set<TEntity>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_baseDal != null)
                {
                    _baseDal.Dispose();
                    _baseDal = null;
                }
            }
            base.Dispose(disposing);
        }

        private IBaseDal _baseDal;
        public IBaseDal GetBaseDal()
        {
            return _baseDal ?? (_baseDal = new BaseDal(this));
        }
    }
}
