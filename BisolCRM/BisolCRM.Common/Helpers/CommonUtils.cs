using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Net.Mail;

namespace BisolCRM.Common.Helpers
{
    public class CommonUtils
    {
      

        public static string GetPropertyPath<TSource>(Expression<Func<TSource, object>> exp)
        {
            var expText = exp.ToString();
            var iPos = expText.IndexOf(".");
            if (iPos > 0)
                return expText.Substring(iPos + 1);

            return null;
        }

        

    }
}
