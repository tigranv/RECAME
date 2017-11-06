using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Interfaces
{
    public interface IObjectVersion
    {
        byte[] UpdateVersion { get; set; }
    }
}
