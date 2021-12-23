namespace Cadastro.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set;}


        // Método Construtor
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;   // O Id esta fazendo referencia a classe EntidadeBase
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString() // Sobreescrever
        {
            // Environmeent.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=nettcore-3.1
            string retorno = "";
            retorno += "                    Genero: " + this.Genero + Environment.NewLine; // Environment.NewLine é uma nova linha
            retorno += "                    Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "                    Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "                    Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "                    Excluido: " + this.Excluido;
            return retorno;
        }

        // Emcapsulamento (metodo)
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
        
    }
    
}