using BisolCRM.DAL.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Interfaces
{
    public interface IFilter
    {
        bool IsEmpty { get; }
        bool IsMatching(ModelBase model);
        HashSet<string> MonitoredProperties { get; set; }
        bool BypassMaxRows { get; set; }
        IQueryable<ModelBase> FilterObjects(IQueryable<ModelBase> query);
        string GetString { get; }

    }
}
