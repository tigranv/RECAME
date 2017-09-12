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

namespace Recame.Common.Helpers
{
    public class CommonUtils
    {

        public static byte[] Compress(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var zipStream = new DeflateStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(zipStream);
                }
                return mso.ToArray();
            }
        }

        public static string Decompress(byte[] data)
        {
            using (var msi = new MemoryStream(data))
            using (var mso = new MemoryStream())
            {
                using (var zipStream = new DeflateStream(msi, CompressionMode.Decompress))
                {
                    zipStream.CopyTo(mso);
                }
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        public static string ComputeHash(string data)
        {
            using (var sha256 = new SHA256Managed())
            {
                var hashArray = sha256.ComputeHash(Encoding.ASCII.GetBytes(data));
                return string.Concat(Array.ConvertAll(hashArray, b => b.ToString("x2")));
            }
        }

        public static string ComputeHMACSHAT256(string data, string key)
        {
            var secretKey = Encoding.UTF8.GetBytes(key);
            var message = Encoding.UTF8.GetBytes(data);
            using (HMACSHA256 hash = new HMACSHA256(secretKey))
            {
                var hashArray = hash.ComputeHash(message);
                return string.Concat(Array.ConvertAll(hashArray, b => b.ToString("x2")));
            }
        }

        public static string ComputeMD5(string data)
        {
            using (var md5 = MD5.Create())
            {
                var hashArray = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
                return string.Concat(Array.ConvertAll(hashArray, b => b.ToString("x2")));
            }
        }

        public static byte[] ComputeMD5Byte(string data)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(data));
            }
        }

        public static int ComputeCheckDigit(long number)
        {
            byte[] digits =
                number.ToString(CultureInfo.InvariantCulture)
                    .PadLeft(12, '0')
                    .ToCharArray()
                    .Select(n => byte.Parse(n.ToString(CultureInfo.InvariantCulture)))
                    .ToArray();
            return (10 - (digits.Select((c, ci) => c * (ci % 2 == 0 ? 1 : 3)).Sum() % 10)) % 10;
        }

        public static long AddCheckDigit(long number)
        {
            return number * 10 + ComputeCheckDigit(number);
        }

        private static Random _randomNumber = new Random();

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            return _randomNumber.Next(minValue, maxValue);
        }

        public static string GetRandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return CalcRandomString(length, valid);
        }

        public static string GetRandomNumericString(int length, string prefix = null)
        {
            const string valid = "1234567890";
            string result = CalcRandomString(length, valid);

            if (prefix == null)
                return CalcRandomString(length, valid);

            result = prefix + result;
            return result;
        }

        private static string CalcRandomString(int length, string valid)
        {
            var res = "";
            var rnd = new Random((int)DateTime.Now.Ticks);
            while (0 < length--)
                res += valid[rnd.Next(valid.Length)];
            return res;
        }


        public static string GetNumberNameTh(int number)
        {
            switch (number)
            {
                case 1:
                    return "First";
                case 2:
                    return "Second";
                case 3:
                    return "Third";
                case 4:
                    return "Fourth";
                case 5:
                    return "Fifth";
                case 6:
                    return "Sixth";
                case 7:
                    return "Seventh";
                case 8:
                    return "Eighth";
                case 9:
                    return "Ninth";
                case 10:
                    return "Tenth";
                case 11:
                    return "Eleventh";
                case 12:
                    return "Twelfth";
                default:
                    return GetNumberName(number);
            }
        }

        public static string GetNumberName(int number)
        {
            if (number == 1)
                return "1st";
            if (number == 2)
                return "2nd";
            if (number == 3)
                return "3rd";
            if (number >= 4)
                return number + "th";
            return number.ToString(CultureInfo.InvariantCulture);
        }

        public static string GetLocalIP()
        {
            var address = Dns.GetHostEntry(Dns.GetHostName()).AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            return address == null ? "" : address.ToString();
        }

        public static string HashPassword(string password, long passwordSalt)
        {
            return ComputeHash(string.Format("{0}_{1}_{0}", password, passwordSalt));
        }

        public static bool IsValidEmail(string emailString)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(emailString);
            if (!match.Success)
                return false;
            return true;
        }

        public static string IdToToken(int id)
        {
            return Convert.ToBase64String(BitConverter.GetBytes(id));
        }

        public static int TokenToId(string token)
        {
            int id = 0;
            try
            {
                id = BitConverter.ToInt32(Convert.FromBase64String(token), 0);
            }
            catch
            {
            }
            return id;
        }

        public static string GenerateToken()
        {
            string guid = Guid.NewGuid().ToString();
            MD5 crypto = MD5.Create();
            byte[] guidBytes = Encoding.ASCII.GetBytes(guid);
            byte[] hash = crypto.ComputeHash(guidBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static long ToUnixTimeStamp(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(datetime - sTime).TotalSeconds;
        }

        public static DateTime FromUnixTimeStamp(long timestamp)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return sTime + TimeSpan.FromSeconds(timestamp);
        }

        public static long GetTimeStampTicks(DateTimeOffset date)
        {
            return date.UtcDateTime.Ticks;
        }

        public static void FtpUploadFile(string url, ICredentials credentials, byte[] fileData)
        {
            FtpWebRequest request = WebRequest.Create(url) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = credentials;
            request.ContentLength = fileData.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(fileData, 0, fileData.Length);
            }
        }

        public static void WebdavMakeDirectory(string url, ICredentials credentials)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Credentials = credentials;
            request.PreAuthenticate = true;
            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();

            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode != HttpStatusCode.NotFound)
                    return;
            }
            finally
            {
                if (response != null)
                    response.Close();
            }

            request = WebRequest.Create(url) as HttpWebRequest;
            request.Credentials = credentials;
            request.PreAuthenticate = true;
            request.Method = WebRequestMethods.Http.MkCol;
            response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                if (ex.Status != WebExceptionStatus.ProtocolError)
                    throw new Exception(Constants.Constants.Errors.CantCreateDirectory, ex);
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }

        public static void WebdavUploadFile(string url, ICredentials credentials, byte[] fileData)
        {
            var handler = new HttpClientHandler();
            handler.Credentials = credentials;
            handler.PreAuthenticate = true;

            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.ExpectContinue = false;
            var response = client.PutAsync(url, new ByteArrayContent(fileData)).Result;
            //if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
            if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 300)
                throw new Exception(Constants.Constants.Errors.ImageUploadFailed);
        }

        public static int C_nk(int n, int k)
        {
            return Convert.ToInt32((Faktorial(n) / (Faktorial(k) * Faktorial(n - k))));
        }

        public static long Faktorial(int n)
        {
            long num = 1;
            if (n <= 1)
            {
                return 1;
            }
            for (int i = 1; i <= n; i++)
            {
                num *= i;
            }
            return num;
        }

        public static ulong RowVersionAsULong(byte[] rowversion)
        {
            return BitConverter.ToUInt64(rowversion.Reverse().ToArray(), 0);
        }

        public static string GetPropertyPath<TSource>(Expression<Func<TSource, object>> exp)
        {
            var expText = exp.ToString();
            var iPos = expText.IndexOf(".");
            if (iPos > 0)
                return expText.Substring(iPos + 1);

            return null;
        }

        public static object DefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);
            return null;
        }

        public static long GetTimeStamp(DateTimeOffset date)
        {
            return (long)(date.UtcDateTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static string GetMessageFromException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;


            return ex.Message;
        }

        public static string SerializeToXml<T>(T source)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var strWriter = new StringWriter())
            {
                var writer = XmlWriter.Create(strWriter);
                serializer.Serialize(writer, source);
                return strWriter.ToString();
            }
        }

        public static byte[] GetBytesFromObject(object obj)
        {
            if (obj == null)
                return null;

            if (obj.GetType().IsPrimitive || obj.GetType().IsValueType)
            {
                if (obj is bool)
                {
                    return BitConverter.GetBytes(Convert.ToBoolean(obj));
                }
                else if (obj is byte)
                {
                    return BitConverter.GetBytes(Convert.ToByte(obj));
                }
                else if (obj is char)
                {
                    return BitConverter.GetBytes(Convert.ToChar(obj));
                }
                else if (obj is DateTime)
                {
                    return BitConverter.GetBytes((Convert.ToDateTime(obj)).ToBinary());
                }
                else if (obj is decimal)
                {
                    int[] bits = decimal.GetBits(Convert.ToDecimal(obj));
                    List<byte> bytes = new List<byte>();
                    foreach (var bit in bits)
                    {
                        bytes.AddRange(BitConverter.GetBytes(bit));
                    }
                    return bytes.ToArray();

                }
                else if (obj is double)
                {
                    return BitConverter.GetBytes(Convert.ToDouble(obj));
                }
                else if (obj is short)
                {
                    return BitConverter.GetBytes(Convert.ToInt16(obj));
                }
                else if (obj is int)
                {
                    return BitConverter.GetBytes(Convert.ToInt32(obj));
                }
                else if (obj is long)
                {
                    return BitConverter.GetBytes(Convert.ToInt64(obj));
                }
                else if (obj is ushort)
                {
                    return BitConverter.GetBytes(Convert.ToInt16(obj));
                }
                else if (obj is uint)
                {
                    return BitConverter.GetBytes(Convert.ToInt32(obj));
                }
                else if (obj is ulong)
                {
                    return BitConverter.GetBytes(Convert.ToInt64(obj));
                }
            }


            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static string GetPropertyName(PropertyInfo property)
        {
            JsonPropertyAttribute att = (JsonPropertyAttribute)Attribute.GetCustomAttribute(property, typeof(JsonPropertyAttribute));
            if (att == null)
                return property.Name;

            return att.PropertyName;
        }

        public static bool TryParseJson(string data, out JToken retJson)
        {
            retJson = null;
            try
            {
                retJson = JToken.Parse(data);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public static bool TryParseXML(string data, out XElement retXML)
        {
            retXML = null;
            try
            {
                retXML = XElement.Parse(data);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public static IEnumerable<List<T>> SplitList<T>(List<T> source, int nSize = 30)
        {
            for (int i = 0; i < source.Count; i += nSize)
            {
                yield return source.GetRange(i, Math.Min(nSize, source.Count - i));
            }
        }
    }
}
