using Recame.DAL.DataContracts;
using Recame.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recame.Common.Constants;

namespace Recame.DAL
{
    public partial class FoodShop : ModelBase, IObjectInfo
    {
        #region IObjectInfo

        public long SelfId
        {
            get { return Id; }
        }

        public ObjectTypeEnum SelfType
        {
            get { return ObjectTypeEnum.Bonus; }
        }

        public override bool IsLoggingChanges
        {
            get { return true; }
        }

        public bool IsSendingChanges
        {
            get { return true; }
        }

        #endregion
    }
}
