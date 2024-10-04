using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteTecnicoTarefas.Models
{
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<TarefaModel> Tarefas { get; set; }
    }
}
