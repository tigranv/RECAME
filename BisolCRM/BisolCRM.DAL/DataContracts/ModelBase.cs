using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.DataContracts
{
    //[KnownType(typeof(AutoFeedUpdate))]
    //[KnownType(typeof(Bet))]
    //[KnownType(typeof(fnBet))]


    [DataContract(IsReference = true)]
    public class ModelBase
    {
        [JsonIgnore]
        public virtual string SelfKey { get { return string.Empty; } }
        // IsLoggingChanges: log changes to history will be disabled by default
        [JsonIgnore]
        public virtual bool IsLoggingChanges { get { return false; } }
        [JsonIgnore]
        public virtual bool IsLoggingDeletesOnly { get { return false; } }
    }
}
