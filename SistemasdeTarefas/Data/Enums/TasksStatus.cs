using System.ComponentModel;

namespace SistemasdeTarefas.Data.Enums
{
    public enum TasksStatus
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluido = 3
    }
}
