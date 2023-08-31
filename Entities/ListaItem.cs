namespace AwesomeDevEvents.API.Entities
{
    public class ListaItem
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int Preco { get; set; }
        public bool IsAtivo { get; set; }
        public Guid IdLista { get; set; }
    }
}