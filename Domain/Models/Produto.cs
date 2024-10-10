using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VendasRestApi.Domain.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id {get; set;}
        public string? Nome {get; set;}
        public double Preco {get; set;}
        public int QuantidadeEmEstoque{get; set;}

    }
}