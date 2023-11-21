using System.ComponentModel.DataAnnotations;

namespace Lista_de_Supermercado.Entities
{
    public class ListaDeCompras
    {
        [Key]
        public int IdItem { get; set; }
        public int IdCarrinho { get; set; }
        public int IdUsuario { get; set; }
        public int IdProduto { get; set; }
        public int IdCupom { get; set; }
        public decimal Produto_Preco_Total { get; set; }
        public bool Situacao_Carrinho { get; set; } 

        public void Update_Preco_Total(decimal preco_Total)
        {
            Produto_Preco_Total = preco_Total;
        }

    }
}
