using FaculdadeGuararapes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeGuararapes.Controllers
{
    public class PushController : WebApiBase<BasePropPush>
    {
        public async override Task<HttpResponseMessage> ListarPush(BasePropPush BasePropPush)
        {
            return await ListPush(BasePropPush);
        }
    }
}
