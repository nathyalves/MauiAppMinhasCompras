using System;
using System.Collections.Generic;
using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Relatorios;

namespace MauiAppMinhasCompras.Services
{
    public static class RelatorioService
    {
        public static void TestarRelatorio()
        {
            List<Produto> produtos = new List<Produto>
            {
                new Produto { Id = 1, Descricao = "Arroz", Preco = 10.0, Quantidade = 2, Categoria = "Alimentos" },
                new Produto { Id = 2, Descricao = "Sabonete", Preco = 2.5, Quantidade = 3, Categoria = "Higiene" },
                new Produto { Id = 3, Descricao = "Feijão", Preco = 8.0, Quantidade = 1, Categoria = "Alimentos" },
                new Produto { Id = 4, Descricao = "Detergente", Preco = 3.0, Quantidade = 4, Categoria = "Limpeza" }
            };

            var produtosAlimentos = RelatorioCompras.FiltrarProdutosPorCategoria(produtos, "Alimentos");
            RelatorioCompras.ExibirRelatorioDeGastosPorCategoria(produtos);
        }
    }
}
