using BisolCRM.DAL.Interfaces.Repository;
using BisolCRM.DAL.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisolCRM.DAL.DataContracts.Filters;

namespace BisolCRM.DAL.Repository
{
    public class RESIDENTCONTRACTDal : CoreDal, IRESIDENTCONTRACTDal
    {
        public RESIDENTCONTRACTDal(BaseDal dal)
            : base(dal)
        {
        }

        public RESIDENTCONTRACT GetRESIDENTCONTRACTById(int id)
        {
            return db.RESIDENTCONTRACTs.FirstOrDefault(x => x.ID == id);
        }

        public List<fnRESIDENTCONTRACT> GetRESIDENTCONTRACTs(FilterRESIDENTCONTRACT filter)
        {
            var query = db.fn_RESIDENTCONTRACT().AsQueryable();
            return filter.FilterObjects(query).ToList();
        }

        public int GetRESIDENTCONTRACTCount(FilterRESIDENTCONTRACT filter)
        {
            var query = db.fn_RESIDENTCONTRACT().AsQueryable();
            return filter.FilterObjectsNoMax(query).Count();
        }
    }
}
