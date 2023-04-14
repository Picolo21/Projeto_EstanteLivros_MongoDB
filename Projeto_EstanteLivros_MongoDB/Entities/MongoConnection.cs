using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Projeto_EstanteLivros_MongoDB.Entities;

namespace Projeto_EstanteLivros_MongoDB
{
    public class MongoConnection
    {
        public MongoClient Client { get; private set; }

        public MongoConnection()
        {
            Client = new MongoClient("mongodb://localhost:27017");
        }

        public void InsertDataBase(Book book)
        {
            var dataBase = Client.GetDatabase("Book");
            if (book.Status.Equals('N'))
            {
                var collection = dataBase.GetCollection<BsonDocument>("Shelf");
                collection.InsertOne(NewDocument(book));
                Console.Clear();
                Console.WriteLine("Cadastro feito com sucesso!");
                Thread.Sleep(3000);
            }
            else if (book.Status.Equals('L'))
            {
                var collection = dataBase.GetCollection<BsonDocument>("Reading");
                collection.InsertOne(NewDocument(book));
                Console.Clear();
                Console.WriteLine("Cadastro feito com sucesso!");
                Thread.Sleep(3000);
            }
            else
            {
                var collection = dataBase.GetCollection<BsonDocument>("Borrowed");
                collection.InsertOne(NewDocument(book));
                Console.Clear();
                Console.WriteLine("Cadastro feito com sucesso!");
                Thread.Sleep(3000);
            }
        }

        public BsonDocument NewDocument(Book book)
        {
            var document = new BsonDocument
            {
                { "Book Name", book.Name },
                { "Authors", book.Authors },
                { "Edition", book.Edition },
                { "ISBN", book.ISBN },
            };
            return document;
        }

        public void Print(char option)
        {
            var dataBase = Client.GetDatabase("Book");

            if (option.Equals('N'))
            {
                var collection = dataBase.GetCollection<BsonDocument>("Shelf");
                var filter = Builders<BsonDocument>.Filter.Regex("Book Name", "");
                var b = collection.Find(filter).ToList();

                foreach (var item in b)
                {
                    var book = BsonSerializer.Deserialize<Book>(item);
                    Console.WriteLine(book.ToString());
                    Console.WriteLine("--------------------------------------------------------------\n");
                }
            }
            else if (option.Equals('L'))
            {
                var collection = dataBase.GetCollection<BsonDocument>("Reading");
                var filter = Builders<BsonDocument>.Filter.Regex("Book Name", "");
                var b = collection.Find(filter).ToList();

                foreach (var item in b)
                {
                    var book = BsonSerializer.Deserialize<Book>(item);
                    Console.WriteLine(book.ToString());
                    Console.WriteLine("--------------------------------------------------------------\n");
                }
            }
            else
            {
                var collection = dataBase.GetCollection<BsonDocument>("Borrowed");
                var filter = Builders<BsonDocument>.Filter.Regex("Book Name", "");
                var b = collection.Find(filter).ToList();

                foreach (var item in b)
                {
                    var book = BsonSerializer.Deserialize<Book>(item);
                    Console.WriteLine(book.ToString());
                    Console.WriteLine("--------------------------------------------------------------\n");
                }
            }
        }

        public void Delete(int option, string title)
        {
            if (option == 1)
            {
                Client.DropDatabase("Book");
                Console.Clear();
                Console.WriteLine("Banco de Dados excluído com sucesso!!!");
            }
            else if(option == 2)
            {
                var dataBase = Client.GetDatabase("Book");
                dataBase.DropCollection("Shelf");
                Console.Clear();
                Console.WriteLine("Coleção excluída com sucesso!!!");
            }
            else if (option == 3)
            {
                var dataBase = Client.GetDatabase("Book");
                var collection = dataBase.GetCollection<BsonDocument>("Shelf");
                var filter = Builders<BsonDocument>.Filter.Regex("Book Name", title);
                collection.DeleteOne(filter);
                Console.Clear();
                Console.WriteLine("Livro excluído com sucesso!!!");
            }
            else if (option == 4)
            {
                var dataBase = Client.GetDatabase("Book");
                dataBase.DropCollection("Reading");
                Console.Clear();
                Console.WriteLine("Coleção excluída com sucesso!!!");
            }
            else if (option == 5)
            {
                var dataBase = Client.GetDatabase("Book");
                var collection = dataBase.GetCollection<BsonDocument>("Reading");
                var filter = Builders<BsonDocument>.Filter.Regex("Book Name", title);
                collection.DeleteOne(filter);
                Console.Clear();
                Console.WriteLine("Livro excluído com sucesso!!!");
            }
            else if (option == 6)
            {
                var dataBase = Client.GetDatabase("Book");
                dataBase.DropCollection("Borrowed");
                Console.Clear();
                Console.WriteLine("Coleção excluída com sucesso!!!");
            }
            else if (option == 7)
            {
                var dataBase = Client.GetDatabase("Book");
                var collection = dataBase.GetCollection<BsonDocument>("Borrowed");
                var filter = Builders<BsonDocument>.Filter.Regex("Book Name", title);
                collection.DeleteOne(filter);
                Console.Clear();
                Console.WriteLine("Livro excluído com sucesso!!!");
            }
        }
    }
}