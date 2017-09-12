using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL.Interfaces
{
    public interface IObjectVersion
    {
        byte[] UpdateVersion { get; set; }
    }
}
