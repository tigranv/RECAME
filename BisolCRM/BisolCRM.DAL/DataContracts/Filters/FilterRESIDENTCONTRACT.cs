using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.DataContracts.Filters
{
    public class FilterRESIDENTCONTRACT : FilterBase
    {
        [DataMember]
        public int? Type { get; set; }
        [DataMember]
        public int? Source { get; set; }

        public override IQueryable<ModelBase> FilterObjects(IQueryable<ModelBase> query)
        {
            return FilterObjects(query.Cast<RESIDENTCONTRACT>());
        }

        public IQueryable<RESIDENTCONTRACT> FilterObjects(IQueryable<RESIDENTCONTRACT> query)
        {
            if (Type.HasValue)
                query = query.Where(x => x.Type == Type);

            return query;
        }

        public IQueryable<fnRESIDENTCONTRACT> FilterObjects(IQueryable<fnRESIDENTCONTRACT> query)
        {
            //if (Type.HasValue)
            //    query = query.Where(x => x.Type == Type);
            return ApplyMaxRows(query);
        }
    }
}
