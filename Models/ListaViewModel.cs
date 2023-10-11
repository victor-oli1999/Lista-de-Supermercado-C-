using AwesomeDevEvents.API.Entities;

namespace Lista_de_Supermercado.Models
{
    public class ListaViewModel
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public bool IsAtivo { get; set; }
        public List<ListaItemViewModel> Item { get; set; }
    }

    public class ListaItemViewModel
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int Preco { get; set; }
    }
}
