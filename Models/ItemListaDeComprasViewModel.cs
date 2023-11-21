namespace Lista_de_Supermercado.Models
{
    public class ItemListaDeComprasViewModel
    {
        public int IdCarrinho { get; set; }
        public int IdProduto { get; set; }
        public int IdCupom { get; set; }
        public decimal Produto_Preco_Total { get; set; }
    }
}
