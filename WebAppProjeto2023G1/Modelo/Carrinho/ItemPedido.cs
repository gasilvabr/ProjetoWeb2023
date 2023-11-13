using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Carrinho
{
    public class ItemPedido
    {
        public long? ItemPedidoId { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get; set; }
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
    }
}
