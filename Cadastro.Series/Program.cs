using System;
#nullable disable // define o contexto de anotação que pode ser anulado e o contexto de aviso anulado como

namespace Cadastro.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio(); // Declarando Repositório para o MENU
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X") // Converte o valor de um caractere Unicode para seu equivalente em maiúsculas.
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("\nObrigado por ultilizar nossos serviços. ");
            Console.ReadLine();
        }

        // Seleção de MENU
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            
            Console.WriteLine("\n      Cadastre Seus Filmes e Séries Favoritos \n");

            Console.WriteLine("                 1- Lista séries");
            Console.WriteLine("                 2- Inserir nova série");
            Console.WriteLine("                 3- Atualizar série");
            Console.WriteLine("                 4- Excluir série");
            Console.WriteLine("                 5- Visualizar série");
            Console.WriteLine("                 C- Limpar Tela");
            Console.WriteLine("                 X- Sair");
            Console.WriteLine();

            Console.Write("       Digite sua Opção: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.Clear();
            return opcaoUsuario;
        }


        // ========== Lista Série - CASO 1 ==========
        private static void ListarSeries()
        {
            Console.WriteLine("\n      Sua Lista de Filme & Série\n");

            var lista = repositorio.Lista(); // Busca da classe SerieRepositorio

            if (lista.Count == 0) // Verifica se a lista ta vazia
            {
                Console.WriteLine("                 Nenhum Conteúdo Cadastrado no Momento. \n");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            foreach (var serie in lista) // Caso, não esteja vazio escreve serie.retornaId () , serie.retornaTitulo() 
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("                  #ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido* " : ""));
            }

        }


        // ========== Inserir Série - CASO 2 ==========
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Filmes | Série\n");

            foreach (int i in Enum.GetValues(typeof(Genero))) // Recupera uma matriz de valores de constantes em uma enumeração especificada.
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i)); // Recupera o nome da constante na enumeração especificada que tem o valor especificado.
                // {0} é substituido por i | {1} é substituido por Enum.GetName(typeof(Genero), i)
            }

            Console.Write("\nDigite o Genêro: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Ano de Lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Descrição: ");
            string entradaDescricao = Console.ReadLine();
            Console.Clear();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), // Criar uma nova serie
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        // ========== Atualizar Série - CASO 3 ==========
        private static void AtualizarSerie()
        {
            ListarSeries();

            Console.Write("\nDigite o Id: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.Clear();
            //https:
            //https:
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("\n{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("\nDigite o Genêro: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título: ");
            string entradaTitulo = (Console.ReadLine());

            Console.Write("Ano de Lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Descrição: ");
            string entradaDescricao = (Console.ReadLine());
            Console.Clear();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                            genero: (Genero)entradaGenero,
                            titulo: entradaTitulo,
                            ano: entradaAno,
                            descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }


        // ========== Excluir Série - CASO 4 ==========
        private static void ExcluirSerie()
        {
            ListarSeries();

            Console.Write("Digite o ID: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.Clear();

            repositorio.excluir(indiceSerie);
        }

        // ========== Visualizar Série - CASO 5 ==========

        private static void VisualizarSerie()
        {
            Console.Clear();
            ListarSeries();
            Console.Write("\n      Selecione Acima ID: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine($"\n      Visualização Completa ");
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine($"\n{serie}"); // Exibir toda Lista (ToString da serie)
            Console.ReadLine();
            Console.Clear();

        }

    }
}