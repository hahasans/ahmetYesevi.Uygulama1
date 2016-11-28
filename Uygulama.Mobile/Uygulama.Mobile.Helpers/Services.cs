using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Uygulama.Mobile.Helper
{
    public class Services
    {
        private string url = "http://dunsev.org/api/Uygulama";
        public List<Model.Uygulama> List()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                var result = JsonConvert.DeserializeObject<List<Model.Uygulama>>(response.Content.ReadAsStringAsync().Result);
                return result;
            }
        }

    }
}
