namespace Lista_de_Supermercado.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int IdCupom { get; set; }
    }
    public class CupomViewModel
    {
        public int IdCupom { get; set; }
        public string? Nome { get; set; }
        public decimal Desconto { get; set; }
    }
}
