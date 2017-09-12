using Recame.Common.Constants;
using Recame.Common.Helpers;
using Recame.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL.DataContracts.Filters
{
    //[KnownType(typeof(FilterMatchReport))]
    [DataContract(IsReference = true)]
    public class FilterBase : IFilter
    {
        private int _maxRows;

        [DataMember]
        public int MaxRows
        {
            get { return _maxRows > 0 ? _maxRows : Constants.Filter.MaxRows; }
            set { _maxRows = value; }
        }

        [DataMember]
        public int? SkeepRows { get; set; }

        [DataMember]
        public bool IsReadOnly { get; set; }

        [DataMember]
        public bool BypassMaxRows { get; set; }

        public bool AsNoTracking { get; set; }
        [DataMember]
        public string LangId { get; set; }



        [DataMember]
        public bool? IsDeleted { get; set; }

        public FilterBase()
        {
            AsNoTracking = true;
            IsDeleted = false;
        }

        public FilterBase(bool isEmpty)
        {
            _isEmpty = isEmpty;
        }

        #region IFilter

        [DataMember]
        public HashSet<string> MonitoredProperties { get; set; }


        public string[] IncludePaths { get; set; }

        private readonly bool _isEmpty;

        public virtual bool IsEmpty
        {
            get { return _isEmpty; }
        }

        public virtual bool IsMatching(ModelBase model)
        {
            var query = new List<ModelBase> { model };
            return FilterObjects(query.AsQueryable()).Any();
        }

        public virtual IQueryable<ModelBase> FilterObjects(IQueryable<ModelBase> query)
        {
            return query;
        }

        public virtual string GetString
        {
            get { return string.Empty; }
        }

        public FilterBase Include<TEntity>(Expression<Func<TEntity, object>> exp)
        {
            var path = CommonUtils.GetPropertyPath<TEntity>(exp);
            if (string.IsNullOrEmpty(path))
                throw new Exception("Invalid property path to include in filter.");

            if (IncludePaths == null)
            {
                IncludePaths = new string[] { path };
                return this;
            }

            if (!IncludePaths.Contains(path))
            {
                IncludePaths = IncludePaths.Concat(new[] { path }).ToArray();
            }

            return this;
        }

        public bool IsIncluded<TEntity>(Expression<Func<TEntity, object>> exp)
        {
            var path = CommonUtils.GetPropertyPath<TEntity>(exp);
            if (string.IsNullOrEmpty(path))
                return false;

            return IncludePaths != null && IncludePaths.Contains(path);
        }
        #endregion

        protected IQueryable<T> ApplyMaxRows<T>(IQueryable<T> query)
        {
            if (!BypassMaxRows)
                query = query.Take(MaxRows);

            return query;
        }

    }
}
