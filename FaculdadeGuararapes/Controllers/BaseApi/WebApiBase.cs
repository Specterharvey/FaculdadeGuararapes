using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using FaculdadeGuararapes.Models;

namespace FaculdadeGuararapes
{
   public abstract class WebApiBase<T>
    {
        private string Url = "http://localhost:52654/api/";

        public abstract Task<HttpResponseMessage> ListarPush(T BasePropPush);

        public async Task<HttpResponseMessage> ListPush(BasePropPush BasePropPush)
        {
            HttpClient client = new HttpClient();
            Uri url = new Uri(string.Concat(Url, "PushIn/PushM"));
            return await client.PostAsJsonAsync(url, BasePropPush);
        }


    }
}
