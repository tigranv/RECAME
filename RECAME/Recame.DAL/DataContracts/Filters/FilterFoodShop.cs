using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL.DataContracts.Filters
{
    public class FilterFoodShop : FilterBase
    {
        [DataMember]
        public int? Type { get; set; }
        [DataMember]
        public int? Source { get; set; }

        #region IFilter

        public override IQueryable<ModelBase> FilterObjects(IQueryable<ModelBase> query)
        {
            return FilterObjects(query.Cast<FoodShop>());
        }

        public IQueryable<FoodShop> FilterObjects(IQueryable<FoodShop> query)
        {
            if (Type.HasValue)
                query = query.Where(x => x.Type == Type);

            return query;
        }

        public IQueryable<fnFoodShop> FilterObjects(IQueryable<fnFoodShop> query)
        {
            if (Type.HasValue)
                query = query.Where(x => x.Type == Type);

            return query;
        }

        #endregion
    }
}
