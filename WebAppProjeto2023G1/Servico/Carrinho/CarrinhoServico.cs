using Modelo.Carrinho;
using Persistencia.DAL.Carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Carrinho
{
    public class CarrinhoServico
    {
        private ItemPedidoDAL itemPedidoDAL = new ItemPedidoDAL();
        public void GravarItemPedido(ItemPedido itemPedido)
        {
            itemPedidoDAL.GravarItemPedido(itemPedido);
        }
    }
}
