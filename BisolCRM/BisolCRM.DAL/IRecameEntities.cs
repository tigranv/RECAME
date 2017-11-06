using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL
{
    public interface IRecameEntities
    {
        bool IsReadOnly { get; }
        bool HasChanges();
        IEnumerable<DbEntityEntry> GetChangedEntries();
        Tentity Find<Tentity, TKey>(params object[] keyValues)
            where Tentity : class
            where TKey : struct, IComparable, IEquatable<TKey>;

        Tentity Find<Tentity>(params object[] keyValues)
            where Tentity : class;

        void Reload(object entity);
        EntityState GetState(object entity);
        void SetState(object entity, EntityState state);
        void SetValues(object from, object to);
        void LoadReference<Tent, Tfunk>(Tent entity, Expression<Func<Tent, Tfunk>> exp)
            where Tent : class
            where Tfunk : class;
    }
}
