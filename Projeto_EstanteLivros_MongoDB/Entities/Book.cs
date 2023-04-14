using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Projeto_EstanteLivros_MongoDB.Entities
{
    [BsonIgnoreExtraElements]
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Book Name")]
        public string Name { get; set; }

        [BsonElement("Authors")]
        public string Authors { get; set; }

        [BsonElement("Edition")]
        public int Edition { get; set; }

        [BsonElement("ISBN")]
        public string ISBN { get; set; }

        public char Status { get; set; }

        public Book(string name, string authors, int edition, string iSBN, char status)
        {
            Name = name;
            Authors = authors;
            Edition = edition;
            ISBN = iSBN;
            Status = status;
        }

        public override string ToString()
        {
            return $"Nome do Livro: {Name}\nAutor(es): {Authors}\nEdição: {Edition}ª Ed\nISBN: {ISBN}\n";
        }
    }
}
