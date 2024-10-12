using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VendasRestApi.Domain.Models
{
    public class Venda
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id {get; set;}
        public DateTime Data {get; set;}
        public List<ItemVenda> Itens {get; set;}
        public double ValorTotal {get; set;}

        public Venda(DateTime data, double valorTotal) 
        {
            this.Data = data;
            this.ValorTotal = valorTotal;
   
        }

        public Venda(){}
        
        
    }
}