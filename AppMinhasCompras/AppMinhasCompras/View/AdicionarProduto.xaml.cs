using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMinhasCompras.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMinhasCompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarProduto : ContentPage
    {
        public AdicionarProduto()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Listagem());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            {
                Produto t = new Produto();
                t.Descricao = txt_descricao.Text;
                t.Preco = txt_preco.Text;
                t.Quantidade = txt_quantidade.Text;


                await App.Database.Save(t);

                await DisplayAlert("Concluido", "O Produto foi salvo", "OK");

                await Navigation.PushAsync(new Listagem());
            }
        }
    }
}