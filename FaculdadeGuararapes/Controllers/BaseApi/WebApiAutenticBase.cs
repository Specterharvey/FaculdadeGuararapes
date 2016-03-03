using FaculdadeGuararapes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeGuararapes.Controllers.BaseApi
{
    public abstract class WebApiAutenticBase<T>
    {
        //private string Url = "http://localhost:52654/api/";
        private string Url = "http://192.168.1.102:52654/api/";

        public abstract Task<HttpResponseMessage> Autenticar(T BaseAlunoAuntetic);

        public async Task<HttpResponseMessage> AutenticPost(BaseAlunoAutentic BaseAlunoAuntetic)
        {
            HttpClient client = new HttpClient();
            Uri url = new Uri(string.Concat(Url, "alun/AutenAluno"));
            return await client.PostAsJsonAsync(url, BaseAlunoAuntetic);
        }


        public abstract Task<HttpResponseMessage> Listar(T BaseAlunoList);

        public async Task<HttpResponseMessage> ListCurso(BaseAlunoAutentic BaseAlunoList)
        {
            HttpClient client = new HttpClient();
            Uri url = new Uri(string.Concat(Url, "alun/ListarCurso"));
            return await client.PostAsJsonAsync(url, BaseAlunoList);
        }     

    }
}
