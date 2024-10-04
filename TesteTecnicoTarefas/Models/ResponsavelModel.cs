using System.Text.Json.Serialization;

namespace TesteTecnicoTarefas.Models
{
    public class ResponsavelModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        [JsonIgnore]
        public ICollection<TarefaModel>? Tarefas { get; set; }

    }
}
