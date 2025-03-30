using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        try
        {
            string descricao = descricaoEntry.Text;
            double quantidade = double.Parse(quantidadeEntry.Text);
            double preco = double.Parse(precoEntry.Text);
            string categoria = categoriaPicker.SelectedItem.ToString();

            Produto novoProduto = new Produto
            {
                Descricao = descricao,
                Quantidade = quantidade,
                Preco = preco,
                Categoria = categoria
            };

            await App.Db.Insert(novoProduto);
            await DisplayAlert("Sucesso", "Produto adicionado com sucesso!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}
