// See https://aka.ms/new-console-template for more information

using System;

namespace Projeto_APP___Decola_Tech_2
{
    class Program
    {
        static FilmesRepositorio repositorio = new FilmesRepositorio();

        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsusario();
           while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                 {
                     case "1":
                         ListarFilmes();
                         break;
                     case "2":
                         InserirFilmes();
                         break;

                     case "3":
                         AtualizarFilmes();
                         break;
                     case "4":
                         ExcluirFilmes();
                         break;
                     case "5":
                         VisualizarFilmes();
                         break;
                     case "C":
                        Console.Clear();
                        break;
                        
                    default:
                        throw new ArgumentOutOfRangeException();
                 }

                 opcaoUsuario = ObterOpcaoUsusario();
            } 
           Console.WriteLine("Obrigada por escolher nossos serviços.");
           Console.ReadLine();
        }

        private static void ExcluirFilmes()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilmes = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceFilmes);
		}

        private static void VisualizarFilmes()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilmes = int.Parse(Console.ReadLine());

			var Filmes = repositorio.RetornaPorId(indiceFilmes);

			Console.WriteLine(Filmes);
		}

         
        private static void ListarFilmes()
         {
             Console.WriteLine("Listar filmes");
             var lista = repositorio.Lista();

             if (lista.Count == 0)
             {
                  Console.WriteLine("Nenhum filme cadastrado.");
                  return;
             }

             foreach (var filmes in lista)
             {
                 Console.WriteLine("#ID  {0}: -  {1}", filmes.retornaId(), filmes.retornaTitulo());
             }
         }

         private static void InserirFilmes()
          {
              Console.WriteLine("Inserir novo filme");

              foreach (int i in Enum.GetValues(typeof(Genero))) 
              {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));            
              }
              
              Console.Write("Digite o gênero entre as opções acima: ");
              int entradaGenero = int.Parse(Console.ReadLine());
            
              Console.Write("Digite o Título do filme: ");
              string entradaTitulo = Console.ReadLine();

              Console.Write("Digite o ano de lançamento: ");
              int entradaAno = int.Parse(Console.ReadLine());
              
              Console.Write("Descreva o filme: ");
              string entradaDescricao = Console.ReadLine();

              Filmes novoFilmes = new Filmes(id: repositorio.ProximoId(),
                                             genero: (Genero)entradaGenero,
                                             titulo: entradaTitulo,
                                             ano: entradaAno,
                                             descricao: entradaDescricao);
               repositorio.Insere(novoFilmes);
          }                       


        private static void AtualizarFilmes()
          {
              Console.WriteLine("Inserir novo filme");
              int indiceFilmes = int.Parse(Console.ReadLine());

              foreach (int i in Enum.GetValues(typeof(Genero))) 
              {
                  Console.WriteLine(" {0}-{1}", i, Enum.GetName(typeof(Genero), i));
              }
              
              Console.Write("Digite o gênero entre as opções acima: ");
              int entradaGenero = int.Parse(Console.ReadLine());
            
              Console.Write("Digite o Título do filme: ");
              string entradaTitulo = Console.ReadLine();

              Console.Write("Digite o ano de lançamento: ");
              int entradaAno = int.Parse(Console.ReadLine());
              
              Console.Write("Digite a descrição do filme: ");
              string entradaDescricao = Console.ReadLine();

              Filmes atualizaFilmes = new Filmes(id: indiceFilmes,
                                             genero: (Genero)entradaGenero,
                                             titulo: entradaTitulo,
                                             ano: entradaAno,
                                             descricao: entradaDescricao);
               
               repositorio.Atualiza(indiceFilmes, atualizaFilmes);
          }
        private static string ObterOpcaoUsusario()
         {
             Console.WriteLine();
             Console.WriteLine("Decola Filmes - Sua plataforma Tech de entretenimento");
             Console.WriteLine("Informe a opção desejada: ");
             
             Console.WriteLine("1 - Listar filmes");
             Console.WriteLine("2 - Inserir novo filme");
             Console.WriteLine("3 - Atualizar filme");
             Console.WriteLine("4 - Excluir filme");
             Console.WriteLine("5 - Visualizar filme");
             Console.WriteLine("C - Limpar tela");
             Console.WriteLine("X - Sair");
             Console.WriteLine();

             string opcaoUsuario = Console.ReadLine().ToUpper();
             Console.WriteLine();
             return opcaoUsuario;


         }
    }
}

