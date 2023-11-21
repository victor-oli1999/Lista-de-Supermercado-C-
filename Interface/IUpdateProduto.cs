using Microsoft.AspNetCore.Mvc;
using Lista_de_Supermercado.Repository;

namespace Lista_de_Supermercado.Interface

{
    public interface IUpdateProduto
    {
        public decimal CalculoPrecoTotal(decimal preco_Item, decimal desconto);
    }
}
