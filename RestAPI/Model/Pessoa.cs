using RestAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Model {
    public class Pessoa : BaseModel {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Endereco { get; set; }
        public string Genero { get; set; }
        public bool Ativo { get; set; }
    }
}
