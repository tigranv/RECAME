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

        public int? BranchId { get; set; }

        public int? CityId { get; set; }
        public int? RegionId { get; set; }
        public int? Id { get; set; }

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
            if (BranchId.HasValue)
                query = query.Where(x => x.BRANCH == BranchId);
            if (Id.HasValue)
                query = query.Where(x => x.ID == Id.Value);
            if (CityId.HasValue)
                query = query.Where(x => x.CITY == CityId);
            if (SkeepRows.HasValue)
                query = query.OrderBy(x => x.ID).Skip(SkeepRows.Value);
            return ApplyMaxRows(query);
        }

        public IQueryable<fnRESIDENTCONTRACT> FilterObjectsNoMax(IQueryable<fnRESIDENTCONTRACT> query)
        {
            if (BranchId.HasValue)
                query = query.Where(x => x.BRANCH == BranchId);
            if (Id.HasValue)
                query = query.Where(x => x.ID == Id.Value);
            if (CityId.HasValue)
                query = query.Where(x => x.CITY == CityId);
            return query;
        }
    }
}
