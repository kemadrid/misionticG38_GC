namespace Avicola.Dominio
{
    public class HistoricoIndicador_Variable
    {
        public int Id {get;set;}
        public HistoricoIndicador HistoricoIndicador {get;set;}
        public Variable Variable {get;set;}
        public float valor_float {get;set;}
        public string valor_string {get; set;}
    }
}