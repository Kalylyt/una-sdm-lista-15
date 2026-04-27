namespace GreenDriveApiSeuRa.Models
{
    public class OrdemReciclagem
    {
        public int Id { get; set; }
        public int BateriaId { get; set; }
        public int EstacaoId { get; set; }
        public string Prioridade { get; set; }
        public decimal CustoProcessamento { get; set; }

        public Bateria? Bateria { get; set; }
        public EstacaoCarga? EstacaoCarga { get; set; }
    }
}