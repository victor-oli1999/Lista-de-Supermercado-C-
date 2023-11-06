namespace Lista_de_Supermercado.Entities
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco_Item { get; set; }
        public decimal Preco_Total { get; set; }
        public int IdCupom{ get; set; }

        public void UpdateCupom(int idCupom, decimal preco_Total)
        {
            IdCupom = idCupom;
            Preco_Total = preco_Total;
        }
    }
}
