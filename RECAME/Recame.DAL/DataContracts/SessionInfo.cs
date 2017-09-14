using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL.DataContracts
{
    [DataContract]
    public class SessionInfo
    {
        public SessionInfo()
        {
            LangId = "en"; //Constants.Languages.English;
        }
        [DataMember]
        public string LangId { get; set; }
        [DataMember]
        public string CurrencyId { get; set; }
        [DataMember]
        public int PartnerId { get; set; }

        [DataMember]
        public int IntegrationType { get; set; }

        [DataMember]
        public string TimeZone { get; set; }
        //[DataMember]
        //public UserSession UserSession { get; set; }
    }
}
