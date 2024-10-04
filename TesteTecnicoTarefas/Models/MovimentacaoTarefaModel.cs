namespace TesteTecnicoTarefas.Models
{
    public class MovimentacaoTarefaModel
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Tipo { get; set; }
        public int TarefaId { get; set; }
        public TarefaModel Tarefa { get; set; }

    }
}
