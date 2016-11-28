using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Uygulama.Read.Model;

namespace Uygulama.Read.Helper
{
    public class Services
    {
        private string url = "http://dunsev.org/api/Uygulama";
        public Message Add(Model.Uygulama item)
        {
            Message result;
            var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, content).Result;
                result = JsonConvert.DeserializeObject<Message>(response.Content.ReadAsStringAsync().Result);
            }
            return result;
        }

        
    }
}
