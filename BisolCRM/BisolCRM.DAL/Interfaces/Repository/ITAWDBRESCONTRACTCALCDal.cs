using BisolCRM.DAL.DataContracts.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Interfaces.Repository
{
    public interface ITAWDBRESCONTRACTCALCDal
    {
        List<fnTAWDBRESCONTRACTCALC> GetTAWDBRESCONTRACTCALCs(FilterTAWDBRESCONTRACTCALC filter);

        TAWDBRESCONTRACTCALC GetTAWDBRESCONTRACTCALCById(int id);
    }
}
