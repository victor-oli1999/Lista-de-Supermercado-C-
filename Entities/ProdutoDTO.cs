using Lista_de_Supermercado.Repository;

namespace Lista_de_Supermercado.Entities
{
    public class ProdutoDTO
    {
        public ProdutoDTO(int id, string nome, decimal preco, int idcupom)
        {
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int IdCupom{ get; set; }
    }
}
