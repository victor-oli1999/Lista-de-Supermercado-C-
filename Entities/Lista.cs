using System.Collections.Generic;

namespace AwesomeDevEvents.API.Entities
{
    public class Lista
    {
        public Lista()
        {
            Item = new List<ListaItem>();
            IsAtivo = false;

        }
        public short Id { get; set; }
        public string Nome { get; set; }
        public List<ListaItem> Item { get; set; }
        public bool IsAtivo { get; set; }

        public void Update(string nome)
        {
            Nome = nome;
        }

        public void Desativo()
        {
            IsAtivo = false;
        }

        public void Ativo()
        {
            IsAtivo = true;
        }
    }
}
