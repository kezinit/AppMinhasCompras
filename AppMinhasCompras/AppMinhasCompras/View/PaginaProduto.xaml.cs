using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMinhasCompras.Model;

namespace AppMinhasCompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaProduto : ContentPage
    {
        public PaginaProduto()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Produto t = new Produto
            {
                Descricao = txt_nome.Text,
                Preco = txt_preco.Text,
                Quantidade = txt_quantidade.Text


            };

            await App.Database.Update(t);

            await DisplayAlert("Sucesso", "O Produto Foi atualizado", "OK");

            await Navigation.PushAsync(new Listagem());
        }

    }
}