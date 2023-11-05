using Lista_de_Supermercado.Entities;
using Lista_de_Supermercado.Repository;

namespace Lista_de_Supermercado.Repository
{
    public class ProdutoRepository
    {
        private List<ProdutoDTO> ListaProdutos { get; }
        public ProdutoRepository()
        {
            ListaProdutos = new List<ProdutoDTO>()
            {
                new ProdutoDTO(1, "PlayStation 5", 4185.90m, 3 /* Id do cupom desconto */),
                new ProdutoDTO(2, "Iphone 15", 10174.95m, 1 /* Id do cupom desconto */),
                new ProdutoDTO(3, "Moto Edge 30", 1699.00m, 1 /* Id do cupom desconto */)
            };
        }
        public ProdutoDTO Obter(int id)
        {
            return ListaProdutos.Find(p => p.Id == id);
        }


    }
}
