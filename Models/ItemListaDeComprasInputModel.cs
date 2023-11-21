namespace Lista_de_Supermercado.Models
{
    public class ItemListaDeComprasInputModel
    {
        public int IdCarrinho { get; set; }
        public int IdUsuario { get; set; }
        public int IdProduto { get; set; }
        public int IdCupom { get; set; }
        public decimal Produto_Preco_Total { get; set; }
        public bool Situacao_Carrinho { get; set; }
    }
}
