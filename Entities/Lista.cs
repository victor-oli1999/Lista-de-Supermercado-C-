namespace AwesomeDevEvents.API.Entities
{
    public class Lista
    {
        public Lista()
        {
            Item = new List<ListaItem>();
            IsAtivo = false;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<ListaItem> Item { get; set; }
        public bool IsAtivo { get; set; }

        public void Update(string nome)
        {
            Nome = nome;
        }

        public void Delete()
        {
            IsAtivo = true;
        }
    }
}
