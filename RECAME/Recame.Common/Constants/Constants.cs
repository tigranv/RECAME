using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recame.Common.Constants
{
    public static class Constants
    {
        public static class Errors
        {
           
           
            public const string EmptyTranslation = "EmptyTranslation";
            public const string WrongHash = "WrongHash";
            
        }

        public class Filter
        {
            public const int MaxRows = 10000;
        }

        public static class Others
        {
            public const int StartDayNumbers = -1;
            public const int EndDayNumbers = 1;
           
        }
    }
}
