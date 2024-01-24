using RestAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestAPI.Data.DTO {
    public class PessoaDTO {

        //JsonPropertyName muda o nome da propriedade para ser exposta no endpoint.
        //JsonIgnore faz com que a propriedade não seja mostrada no endpoint.

        public int Id { get; set; }

        [JsonPropertyName("PrimeiroNome")]
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Endereco { get; set; }
        //[JsonIgnore]
        public string Genero { get; set; }
    }
}
