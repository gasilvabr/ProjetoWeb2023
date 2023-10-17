using Modelo.Carrinho;
using Servico.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppProjeto2023G2.Areas.Carrinho.Controllers
{
    public class CarrinhosController : Controller
    {
		private ProdutoServico produtoServico = new ProdutoServico();

		// GET: Carrinho/Carrinhos
		public ActionResult Create()
		{
			IEnumerable<ItemCarrinho> carrinho = HttpContext.Session["carrinho"] as IEnumerable<ItemCarrinho>;
						if (carrinho == null)
			{
				carrinho = new List<ItemCarrinho>();
				HttpContext.Session["carrinho"] = carrinho;
			}
			return View(carrinho);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public PartialViewResult AddProduto(FormCollection collection)
		{
			List<ItemCarrinho> carrinho = HttpContext.Session["carrinho"] as List<ItemCarrinho>;
			var produto = produtoServico.ObterProdutoPorId(Convert.ToInt32(collection.Get("idproduto")));
			var itemCarrinho = new ItemCarrinho()
			{
				Produto = produto,
				Quantidade = 1,
				ValorUnitario = 1 // produto.ValorUnitario
			};
			carrinho.Add(itemCarrinho);
			HttpContext.Session["carrinho"] = carrinho;
			return PartialView("_ItensCarrinho", carrinho);
		}

	}
}