using BisolCRM.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Interfaces
{
    public interface IObjectInfo
    {
        long SelfId { get; }

        string SelfKey { get; }

        ObjectTypeEnum SelfType { get; }

        bool IsLoggingChanges { get; }
        bool IsSendingChanges { get; }
    }
}
