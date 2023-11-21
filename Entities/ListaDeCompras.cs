using Lista_de_Supermercado.Models;
using System.ComponentModel.DataAnnotations;

namespace Lista_de_Supermercado.Entities
{
    public class ListaDeCompras
    {
        public List<Item> ItemListaDeCompras { get; set; }
        public decimal Valor_Total { get; set; }

    }
    public class Item
    {
        public string Nome { get; set; }
        public string Cupom { get; set; }
        public decimal Produto_Preco_Total { get; set; }

        //public void AddNome(string nome)
        //{
        //    Nome = nome;
        //}
        //public void AddCupom(string cupom)
        //{
        //    Cupom = cupom;
        //}
        //public void AddProduto_Preco_Total(decimal produto_Preco_Total)
        //{
        //    Produto_Preco_Total = produto_Preco_Total;
        //}
    }
}
