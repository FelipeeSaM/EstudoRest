using RestAPI.Model.Base;

namespace RestAPI.Model {
    public class Livros : BaseModel {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public double Preco { get; set; }
        public bool Estoque { get; set; }
    }
}