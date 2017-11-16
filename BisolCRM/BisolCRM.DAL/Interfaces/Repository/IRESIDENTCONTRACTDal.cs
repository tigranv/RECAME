using BisolCRM.DAL.DataContracts.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Interfaces.Repository
{
    public interface IRESIDENTCONTRACTDal
    {
        List<fnRESIDENTCONTRACT> GetRESIDENTCONTRACTs(FilterRESIDENTCONTRACT filter);

        RESIDENTCONTRACT GetRESIDENTCONTRACTById(int id);

        int GetRESIDENTCONTRACTCount(FilterRESIDENTCONTRACT filter);

    }
}
