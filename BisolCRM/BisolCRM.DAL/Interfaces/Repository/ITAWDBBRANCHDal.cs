using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Interfaces.Repository
{
    public interface ITAWDBBRANCHDal
    {
        List<TAWDBBRANCH> GetTAWDBBRANCHs();

        TAWDBBRANCH GetTAWDBBRANCHById(int id);
    }
}
