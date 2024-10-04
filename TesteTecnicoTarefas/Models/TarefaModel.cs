using System.Text.Json.Serialization;

namespace TesteTecnicoTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public int CategoriaId { get; set; }
        [JsonIgnore]
        public CategoriaModel? Categoria { get; set; }

        public int ResponsavelId { get; set; }
        [JsonIgnore]
        public ResponsavelModel? Responsavel { get; set; }

        [JsonIgnore]
        public ICollection<MovimentacaoTarefaModel>? Movimentacoes { get; set; }
    }
}
