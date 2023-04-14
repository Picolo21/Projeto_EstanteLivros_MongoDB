using Projeto_EstanteLivros_MongoDB;
using Projeto_EstanteLivros_MongoDB.Entities;

public class Program
{
    private static int Menu()
    { 
        Console.Clear();
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("|".PadRight(54) + "|");
        Console.WriteLine("|                   MENU DE OPÇÕES".PadRight(54) + "|");
        Console.WriteLine("|".PadRight(54) + "|");
        Console.WriteLine("|   [1] - Inserir um livro".PadRight(54) + "|");
        Console.WriteLine("|   [2] - Editar um livro".PadRight(54) + "|");
        Console.WriteLine("|   [3] - Remover um livro".PadRight(54) + "|");
        Console.WriteLine("|   [4] - Imprimir lista de livros".PadRight(54) + "|");
        Console.WriteLine("|   [5] - Sair".PadRight(54) + "|");
        Console.WriteLine("|".PadRight(54) + "|");
        Console.WriteLine("-------------------------------------------------------\n");

        Console.Write("Escolha uma opção: ");
        int op = int.Parse(Console.ReadLine());

        return op;
    }

    private static void PrintMenu(MongoConnection mongo)
    {
        int op;
        do
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|".PadRight(67) + "|");
            Console.WriteLine("|                   MENU DE IMPRESSÃO".PadRight(67) + "|");
            Console.WriteLine("|".PadRight(67) + "|");
            Console.WriteLine("|   [1] - Imprimir todos os livros do banco de dados".PadRight(67) + "|");
            Console.WriteLine("|   [2] - Imprimir todos os livros com o status NA ESTANTE".PadRight(67) + "|");
            Console.WriteLine("|   [3] - Imprimir todos os livros com o status LENDO".PadRight(67) + "|");
            Console.WriteLine("|   [4] - Imprimir todos os livros com o status EMPRESTADO".PadRight(67) + "|");
            Console.WriteLine("|   [5] - Voltar ao Menu Principal".PadRight(67) + "|");
            Console.WriteLine("|".PadRight(67) + "|");
            Console.WriteLine("--------------------------------------------------------------------\n");

            Console.Write("Escolha uma opção: ");
            op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    PrintAll(mongo);
                    break;
                case 2:
                    PrintAllShelf(mongo);
                    break;
                case 3:
                    PrintAllReading(mongo);
                    break;
                case 4:
                    PrintAllBorrowed(mongo);
                    break;
                case 5:
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida. Por favor escolha uma opção válida");
                    Thread.Sleep(3000);
                    break;
            }
        } while (op != 5);
    }

    private static void UpdateMenu()
    {
        int op;
        do
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("|".PadRight(54) + "|");
            Console.WriteLine("|                   MENU DE UPDATE".PadRight(54) + "|");
            Console.WriteLine("|".PadRight(54) + "|");
            Console.WriteLine("|   [1] - Editar status de um livro".PadRight(54) + "|");
            Console.WriteLine("|   [2] - Editar nome do livro".PadRight(54) + "|");
            Console.WriteLine("|   [3] - Editar autor do livro".PadRight(54) + "|");
            Console.WriteLine("|   [4] - Editar edição do livro".PadRight(54) + "|");
            Console.WriteLine("|   [5] - Editar número do ISBN".PadRight(54) + "|");
            Console.WriteLine("|   [6] - Voltar ao Menu Principal".PadRight(54) + "|");
            Console.WriteLine("|".PadRight(54) + "|");
            Console.WriteLine("-------------------------------------------------------\n");

            Console.Write("Escolha uma opção: ");
            op = int.Parse(Console.ReadLine());
        } while (op != 6);
    }

    private static void DeleteMenu(MongoConnection mongo)
    {
        int op;
        do
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("|".PadRight(55) + "|");
            Console.WriteLine("|                   MENU DE DELEÇÃO".PadRight(55) + "|");
            Console.WriteLine("|".PadRight(55) + "|");
            Console.WriteLine("|   [1] - Deletar todo o Banco de Dados".PadRight(55) + "|");
            Console.WriteLine("|   [2] - Deletar toda a Coleção NA ESTANTE".PadRight(55) + "|");
            Console.WriteLine("|   [3] - Deletar um livro que está NA ESTANTE".PadRight(55) + "|");
            Console.WriteLine("|   [4] - Deletar toda a Coleção LENDO".PadRight(55) + "|");
            Console.WriteLine("|   [5] - Deletar um livro que está LENDO".PadRight(55) + "|");
            Console.WriteLine("|   [6] - Deletar toda a Coleção EMPRESTADO".PadRight(55) + "|");
            Console.WriteLine("|   [7] - Deletar um livro que está EMPRESTADO".PadRight(55) + "|");
            Console.WriteLine("|   [8] - Voltar ao Menu Principal".PadRight(55) + "|");
            Console.WriteLine("--------------------------------------------------------\n");

            Console.Write("Escolha uma opção: ");
            op = int.Parse(Console.ReadLine());

            
        } while (op != 8);
    }

    private static void Main(string[] args)
    {
        MongoConnection mongo = new MongoConnection();

        int option;
        do
        {
            option = Menu();
            switch (option)
            {
                case 1:
                    InsertBook(mongo);
                    break;
                case 2:
                    UpdateMenu();
                    break;
                case 3:
                    DeleteMenu(mongo);
                    //DeleteBook(mongo);
                    
                    break;
                case 4:
                    PrintMenu(mongo);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Finalizando aplicação...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Aplicação encerrada!!!");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida. Por favor escolha uma opção válida");
                    Thread.Sleep(3000);
                    break;
            }
        } while (option != 5);
    }

    private static void InsertBook(MongoConnection mongo)
    {
        string bookName = "", authors = "", isbn = "";
        int edition = 0;
        char status = 'A';
        while ((status != 'N') && (status != 'L') && (status != 'E'))
        {
            Console.Clear();
            Console.Write("Digite o nome do livro: ");
            bookName = Console.ReadLine();
            Console.Write("Digite o(s) nome(s) do(s) autor(es): ");
            authors = Console.ReadLine();
            Console.Write("Digite a edição do livro: ");
            edition = int.Parse(Console.ReadLine());
            Console.Write("Digite o número do ISBN (xxx-x-xx-xxxxxx-x): ");
            isbn = Console.ReadLine();
            Console.Write("Digite o status que o livro se encontra ([N] - na estante | [L] - lendo | [E] - emprestado): ");
            status = char.Parse(Console.ReadLine().ToUpper());
            if ((status == 'N') || (status == 'L') || (status == 'E'))
            {
                Book book = new Book(bookName, authors, edition, isbn, status);
                mongo.InsertDataBase(book);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Você não informou um status válido! Por favor, informe um status válido");
                Thread.Sleep(5000);
            }
        }

        
    }

    private static void PrintAllShelf(MongoConnection mongo)
    {
        do
        {
            Console.Clear();
            mongo.Print('N');
            Console.WriteLine("Aperte ENTER para voltar ao Menu de Impressão");
        } while (Console.ReadKey().Key != ConsoleKey.Enter);
    }

    private static void PrintAllReading(MongoConnection mongo)
    {
        do
        {
            Console.Clear();
            mongo.Print('L');
            Console.WriteLine("Aperte ENTER para voltar ao Menu de Impressão");
        } while (Console.ReadKey().Key != ConsoleKey.Enter);
    }

    private static void PrintAllBorrowed(MongoConnection mongo)
    {
        do
        {
            Console.Clear();
            mongo.Print('E');
            Console.WriteLine("Aperte ENTER para voltar ao Menu de Impressão");
        } while (Console.ReadKey().Key != ConsoleKey.Enter);
    }

    private static void PrintAll(MongoConnection mongo)
    {
        do
        {
            Console.Clear();
            mongo.Print('N');
            mongo.Print('L');
            mongo.Print('E');
            Console.WriteLine("Aperte ENTER para voltar ao Menu de Impressão");
        } while (Console.ReadKey().Key != ConsoleKey.Enter);
    }

    private static void DeleteBook()
    {
    }
}