﻿using Modelo.Carrinho;
using Servico.Cadastros;
using Servico.Carrinho;
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
		private CarrinhoServico carrinhoServico = new CarrinhoServico();

		// GET: Carrinho/Carrinhos
		public ActionResult Create()
		{
			IEnumerable<ItemCarrinho> carrinho = HttpContext.Session["carrinho"] as IEnumerable<ItemCarrinho>;
			if (carrinho == null)
			{
				carrinho = new List<ItemCarrinho>();
				HttpContext.Session["carrinho"] = carrinho;
			}
			PopularViewBag();
			return View(carrinho);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddProduto(FormCollection collection)
		{
			List<ItemCarrinho> carrinho = HttpContext.Session["carrinho"] as List<ItemCarrinho>;
			var produto2 = produtoServico.ObterProdutoPorId(Convert.ToInt32(collection.Get("ItemCarrinhoId")));
			var qtd = Convert.ToInt32(collection.Get("Quantidade"));
			//var produto = produtoServico.ObterProdutoPorId(Convert.ToInt32(collection.Get("idproduto")));
			var itemCarrinho = new ItemCarrinho()
			{
				Produto = produto2,
				Quantidade = qtd,
				ValorUnitario = 1 // produto.ValorUnitario
			};
			carrinho.Add(itemCarrinho);
			HttpContext.Session["carrinho"] = carrinho;
			//return PartialView("_ItensCarrinho", carrinho);
			return RedirectToAction("Create");
		}

		private void PopularViewBag()
		{
			ViewBag.ItemCarrinhoId = new SelectList(produtoServico.ObterProdutosClassificadosPorNome(),"ProdutoId", "Nome");
		}
		// POST: Carrinho/Carrinhos
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(FormCollection collection)
		{
			IEnumerable<ItemCarrinho> carrinho = HttpContext.Session["carrinho"] as IEnumerable<ItemCarrinho>;
			if (carrinho == null)
			{
				carrinho = new List<ItemCarrinho>();
				HttpContext.Session["carrinho"] = carrinho;
			}
			// Cadastra Pedido
			DateTime d = DateTime.Now;
			foreach (ItemCarrinho itemCarrinho in carrinho)
			{
				long produtoId = (long) itemCarrinho.Produto.ProdutoId;
				var itemPedido = new ItemPedido()
				{
					Usuario = "Teste",
					Data = d,
					ProdutoId = produtoId,
					Quantidade = itemCarrinho.Quantidade,
					ValorUnitario = itemCarrinho.ValorUnitario
				};
				carrinhoServico.GravarItemPedido(itemPedido);
			}

			// Limpa Carrinho
			carrinho = new List<ItemCarrinho>();
			HttpContext.Session["carrinho"] = carrinho;
			return RedirectToAction("Create");
		}


	}
}