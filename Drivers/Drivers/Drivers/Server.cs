using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Drivers {

    public static class Server {

        public static string PostQuery(string PHPpath, string query) {

            string response = "";

            try {

                byte[] data = Encoding.UTF8.GetBytes(query);

                HttpWebRequest HTRQ = HttpWebRequest.CreateHttp(PHPpath);
                HTRQ.Method = "POST";
                HTRQ.ContentType = "application/x-www-form-urlencoded";
                HTRQ.ContentLength = data.Length;

                Stream strw = HTRQ.GetRequestStream();
                strw.Write(data, 0, data.Length);
                strw.Close();

                HttpWebResponse HTPR = HTRQ.GetResponse() as HttpWebResponse;
                StreamReader str = new StreamReader(HTPR.GetResponseStream());

                response = str.ReadLine();
                str.Close();
                HTPR.Close();
            }
            catch { }

            return response == "" || response == "<!-- zzz <!--]-->" ? "{ }" : response;
        }

        public static List<T> ParseQuery<T>(string JSON) where T : IParseble {

            return JSON == "{ }"? null : JsonConvert.DeserializeObject<List<T>>(JSON);
        }
    }
}
