namespace Cadastro.Series
{
    public class SerieRepositorio : IRepositorio<Serie> // <Serie>, puxa da classe Serie
    {
        private List<Serie> listaSerie = new List<Serie>(); // Cria uma variavel com a lista Serie
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
        

    }
}