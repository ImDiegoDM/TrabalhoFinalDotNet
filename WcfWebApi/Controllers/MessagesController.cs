using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using apis.Models;

namespace WcfWebApi.Controllers
{

    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {

        static HttpClient client;
        
        public void messageSend([FromBody] Message message)
        {
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var msg = new Message { nome = message.nome };
                var json = JsonConvert.SerializeObject(msg);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = string.Empty;
                var service = "http://localhost/WcfRest/Service1.svc/";
                HttpResponseMessage response = client.PostAsync(service + "queue", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                }

                if (result != "OK")
                {
                    throw new OperationCanceledException();
                }
            } catch (Exception) {
                throw;
            }
        }
    }
}
