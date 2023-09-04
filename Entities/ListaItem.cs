namespace AwesomeDevEvents.API.Entities
{
    public class ListaItem
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int Preco { get; set; }
        public bool IsAtivo { get; set; }
        public short IdLista { get; set; }
    }
}