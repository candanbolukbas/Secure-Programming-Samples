using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace _4_DirectObjRef
{
    public static class IndirectRefMap
    {
        public static string GetIndirectRef(this string directRef)
        {
            var map = (Dictionary<string, string>)HttpContext.Current.Session["Map"];
            return map == null ? AddDirectRef(directRef) : map[directRef];
        }

        public static string GetDirectRef(this string indirectRef)
        {
            var map = HttpContext.Current.Session["Map"];

            if (map == null)
            {
                throw new ApplicationException("No map found");
            }

            return ((Dictionary<string, string>)map)[indirectRef];
        }

        private static string AddDirectRef(string directRef)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[32];
            rng.GetBytes(buff);

            //string indirectRefGuid = new Guid().ToString();

            var indirectRef = HttpServerUtility.UrlTokenEncode(buff);

            var map = new Dictionary<string, string>
        {
          {directRef, indirectRef},
          {indirectRef, directRef}
        };

            HttpContext.Current.Session["Map"] = map;
            return indirectRef;
        }
    }
}