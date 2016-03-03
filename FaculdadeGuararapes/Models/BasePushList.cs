using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeGuararapes.Models
{
    public class BasePushList
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("curso")]
        public string Curso { get; set; }
        [JsonProperty("periodo")]
        public string Periodo { get; set; }
        [JsonProperty("turno")]
        public string Turno { get; set; }
        [JsonProperty("semestre")]
        public string Semestre { get; set; }
        [JsonProperty("Menssagem")]
        public string Menssagem { get; set; }
    }
}
