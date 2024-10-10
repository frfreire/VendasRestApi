using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasRestApi.Domain.Models
{
    public class ItemVenda
    {
        public string ProductId {get; set;}
        public int Quantidade {get; set;}
        public double Preco {get; set;}
    }
}