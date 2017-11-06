using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Interfaces.Repository
{
    public interface ITAWDBREGIONDal
    {
        List<TAWDBREGION> GetTAWDBREGIONs();

        TAWDBREGION GetTAWDBREGIONById(int id);
    }
}
