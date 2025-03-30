using System;
using System.Collections.Generic;
using System.Linq;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Relatorios
{
    public static class RelatorioCompras
    {
        public static List<Produto> FiltrarProdutosPorCategoria(List<Produto> produtos, string categoria)
        {
            return produtos.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static void ExibirRelatorioDeGastosPorCategoria(List<Produto> produtos)
        {
            var gastosPorCategoria = produtos
                .GroupBy(p => p.Categoria)
                .Select(g => new
                {
                    Categoria = g.Key,
                    TotalGasto = g.Sum(p => p.Preco * p.Quantidade)
                });

            foreach (var gasto in gastosPorCategoria)
            {
                Console.WriteLine($"Categoria: {gasto.Categoria}, Total Gasto: {gasto.TotalGasto:C}");
            }
        }
    }
}
