using System;
using System.Collections.Generic;
using System.Linq;
using MauiAppMinhasCompras.Models;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class RelatorioPage : ContentPage
    {
        public RelatorioPage()
        {
            InitializeComponent();
            CarregarRelatorio();
        }

        private async void CarregarRelatorio()
        {
            try
            {
                List<Produto> produtos = await App.Db.GetAll();

                var relatorio = produtos
                    .GroupBy(p => p.Categoria)
                    .Select(g => new
                    {
                        Categoria = g.Key,
                        TotalGasto = g.Sum(p => p.Preco * p.Quantidade)
                    })
                    .ToList();

                RelatorioListView.ItemsSource = relatorio;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}



