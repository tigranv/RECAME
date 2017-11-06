using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.DataContracts.Filters
{
    public class FilterTAWDBRESCONTRACTCALC : FilterBase
    {
        [DataMember]
        public int? Type { get; set; }
        [DataMember]
        public int? Source { get; set; }

        public override IQueryable<ModelBase> FilterObjects(IQueryable<ModelBase> query)
        {
            return FilterObjects(query.Cast<TAWDBRESCONTRACTCALC>());
        }

        public IQueryable<TAWDBRESCONTRACTCALC> FilterObjects(IQueryable<TAWDBRESCONTRACTCALC> query)
        {
            if (Type.HasValue)
                query = query.Where(x => x.Type== Type);

            return query;
        }

        public IQueryable<fnTAWDBRESCONTRACTCALC> FilterObjects(IQueryable<fnTAWDBRESCONTRACTCALC> query)
        {
            if (Type.HasValue)
                query = query.Where(x => x.Type == Type);
            return ApplyMaxRows(query);
        }
    }
}
