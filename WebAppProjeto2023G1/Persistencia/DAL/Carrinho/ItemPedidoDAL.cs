using Modelo.Carrinho;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Carrinho
{
    public class ItemPedidoDAL
    {
        private EFContext context = new EFContext();
        public void GravarItemPedido(ItemPedido itemPedido)
        {
            if (itemPedido.ItemPedidoId == null)
            {
                context.ItemPedidos.Add(itemPedido);
            }
            else
            {
                context.Entry(itemPedido).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
