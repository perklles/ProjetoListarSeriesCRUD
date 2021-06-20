using System;

        // Programa para listar series com CRUD

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    Listarseries();
                    break;

                    case "2":
                    InserirSeries();
                    break;

                    case "3":
                    AtualizarSeries();
                    break;

                    case "4":
                   ExcluirSeries();
                    break;

                    case "5":
                   VisualizarSeries();
                    break; 

                    case "C":
                    Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigada Por Utilizar Nosso Serviço.");
            Console.ReadLine();

        }

        private static void Listarseries()
        {
            Console.WriteLine("Listar Séries");

            var Lista = repositorio.Lista();

            if (Lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada!");
                return;
            }

            foreach (var Series in Lista)
            {
                var excluido = Series.retornaExcluido();

                Console.WriteLine("#ID {0}: . {1} . {2}", Series.retornaId(), Series.retornaTitulo(), (excluido ? "Excluído" : ""));

                
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir Nova Série!");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genero entre as Opções Acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Serie: ");
            string entradaTitutlo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Incio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitutlo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Insere(novaSerie);

        }

        private static void AtualizarSeries()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitutlo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitutlo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {

            Console.WriteLine();
            Console.WriteLine(">> DIOFLIX <<");
            Console.WriteLine("Digite uma opção:");

            Console.WriteLine("[1] - Listar Séries");
            Console.WriteLine("[2] - Inserir Nova Série");
            Console.WriteLine("[3] - Atualizar Série");
            Console.WriteLine("[4] - Excluir Série");
            Console.WriteLine("[5] - Visualizar Série");
            Console.WriteLine("[C] - Limpar Tela");
            Console.WriteLine("[X] - Sair do Programa");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
