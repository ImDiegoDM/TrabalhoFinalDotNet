using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfWebService
{
    public class MessageRepository
    {

        public List<Msg> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/WcfRest/Service1.svc/");
                List<Msg> listaMsgs = null;
                var response = client.GetAsync($"queue").Result;

                if (response.IsSuccessStatusCode)
                {
                    listaMsgs = JsonConvert.DeserializeObject<List<Msg>>(response.Content.ReadAsStringAsync().Result);
                }

                return listaMsgs;
            }
        }
    }
}
