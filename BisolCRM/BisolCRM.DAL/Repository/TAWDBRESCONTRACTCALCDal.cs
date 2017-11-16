using BisolCRM.DAL.DataContracts.Filters;
using BisolCRM.DAL.Interfaces.Repository;
using BisolCRM.DAL.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Repository
{
    public class TAWDBRESCONTRACTCALCDal : CoreDal, ITAWDBRESCONTRACTCALCDal
    {
        public TAWDBRESCONTRACTCALCDal(BaseDal dal)
            : base(dal)
        {
        }

        public TAWDBRESCONTRACTCALC GetTAWDBRESCONTRACTCALCById(int id)
        {
            return db.TAWDBRESCONTRACTCALCs.FirstOrDefault(x => x.ID == id);
        }

        public List<fnTAWDBRESCONTRACTCALC> GetTAWDBRESCONTRACTCALCs(FilterTAWDBRESCONTRACTCALC filter)
        {
            var query = db.fn_TAWDBRESCONTRACTCALC().AsQueryable();
            return filter.FilterObjects(query).ToList();
        }
    }
}
