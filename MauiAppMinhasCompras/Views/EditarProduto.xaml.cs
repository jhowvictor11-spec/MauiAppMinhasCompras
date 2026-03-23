using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;

            if (produto_anexado == null)
            {
                await Shell.Current.DisplayAlert("Erro", "Produto não encontrado", "OK");
                return;
            }

            double quantidade, preco;

            if (!double.TryParse(txt_quantidade.Text, out quantidade) ||
                !double.TryParse(txt_preco.Text, out preco))
            {
                await Shell.Current.DisplayAlert("Erro", "Digite valores válidos", "OK");
                return;
            }

            Produto p = new Produto
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = quantidade,
                Preco = preco
            };

            await App.Db.Update(p);

            await Shell.Current.DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
