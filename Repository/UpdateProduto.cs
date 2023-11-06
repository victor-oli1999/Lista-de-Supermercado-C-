using Microsoft.AspNetCore.Mvc;
using Lista_de_Supermercado.Interface;

namespace Lista_de_Supermercado.Repository
{
    public class UpdateProduto : IUpdateProduto
    {
        public decimal CalculoPrecoTotal(decimal preco_Item, decimal desconto)
        {
            decimal preco_Total = preco_Item - (preco_Item * desconto);
            return preco_Total;
        }
    }
}
