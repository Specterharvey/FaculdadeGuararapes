using FaculdadeGuararapes.Controllers.BaseApi;
using FaculdadeGuararapes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeGuararapes.Controllers
{
    public class AlunoController : WebApiAutenticBase<BaseAlunoAutentic>
    {
        public async override Task<HttpResponseMessage> Autenticar(BaseAlunoAutentic BaseAlunoAuntetic)
        {
            return await AutenticPost(BaseAlunoAuntetic);
        }

        public async override Task<HttpResponseMessage> Listar(BaseAlunoAutentic BaseAlunoAuntetic)
        {
            return await ListCurso(BaseAlunoAuntetic); 
        }

       
    }
}
