using AppLoja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLoja.Pages.Venda
{
    public partial class VendaPage : ContentPage
    {
        Model.Venda Venda;

        IList<Model.Produto> Produtos = new List<Model.Produto>();
        IList<Model.ProdutoVenda> ProdutosVenda = new List<Model.ProdutoVenda>();

        public VendaPage()
        {
            InitializeComponent();

            //incializa Venda
            Venda = new Model.Venda();

            //recebendo dados
            using (var dados = new DataAccess())
            {
                Produtos = dados.GetProdutos();
            }

            //iniciando ComboBoxs
            foreach (var produto in Produtos)
            {
                PickerProduto.Items.Add(produto.ToString());
            }

            //ao escolher o produto chama o valor do produto
            PickerProduto.SelectedIndexChanged += PickerProduto_SelectedIndexChanged;

            //verificar a quantidade do produto
            EntryQuantidade.TextChanged += EntryQuantidade_TextChanged;

            //button add produto
            ButtonAdd.Clicked += ButtonAdd_Clicked;

            //button salvar
            ButtonSalvar.Clicked += ButtonSalvar_Clicked;

            //modelo da listview
            lvProdutos.ItemTemplate = new DataTemplate(typeof(ProdutoVendaCell));
        }

        private void EntryQuantidade_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int valorEstoque;

                //valor digitado
                var valor = Convert.ToInt32(EntryQuantidade.Text);

                //produto selecionado no picker
                var produto = Produtos[PickerProduto.SelectedIndex];

                //valor do estoque
                using (var dados = new DataAccess())
                {
                    var estoque = dados.GetEstoques().Where(c => c.IdProduto == produto.IdProduto).First();
                    valorEstoque = estoque.Quantidade;
                    foreach (var p in ProdutosVenda)
                    {
                        if(p.Produto.IdProduto == produto.IdProduto)
                        {
                            valorEstoque -= p.Quantidade;
                        }
                    }
                    
                }

                if (valor > valorEstoque)
                {
                    DisplayAlert("Erro", "O estoque possui apenas " + valorEstoque + " " + produto.Descricao + "(s)", "OK");
                    EntryQuantidade.Text = valorEstoque.ToString();
                }

            }catch(Exception ex)
            {

            }
        }

        private void PickerProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PickerProduto.SelectedIndex >= 0)
            {
                EntryValorUnit.Text = Produtos[PickerProduto.SelectedIndex].Preco.ToString();
            }
        }

        private void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            DatePickerVenda.IsEnabled = false;

            //produto selecionado no picker
            var produto = Produtos.Where(p => p.Descricao == PickerProduto.Items[PickerProduto.SelectedIndex]).First();

            //cria novo produto Venda
            ProdutoVenda produtoVenda = new ProdutoVenda()
            {

                Produto = produto,
                Quantidade = Convert.ToInt32(EntryQuantidade.Text),
                Preco = Convert.ToDouble(EntryValorUnit.Text),
            };

            //armazenando produtosVenda
            ProdutosVenda.Add(produtoVenda);


            //ativa botao salvar
            ButtonSalvar.IsEnabled = true;

            //limpa dados
            PickerProduto.SelectedIndex = -1;
            EntryQuantidade.Text = string.Empty;
            EntryValorUnit.Text = string.Empty;

            //calcula o total
            if (!lbValorTotal.Equals(string.Empty))
            {
                lbValorTotal.Text = (Convert.ToDouble(lbValorTotal.Text) + (produtoVenda.Quantidade * produtoVenda.Preco)).ToString();
            }
            else
            {
                lbValorTotal.Text = (produtoVenda.Quantidade * produtoVenda.Preco).ToString();
            }

            lvProdutos.ItemsSource = null;

            lvProdutos.ItemsSource = ProdutosVenda;

        }

        private async void ButtonSalvar_Clicked(object sender, EventArgs e)
        {
            //dados para Venda
            Venda.DataVenda = String.Format("{0:d}", DatePickerVenda.Date);
            Venda.ValorTotal = Convert.ToDouble(lbValorTotal.Text);

            Venda.Produtos = ProdutosVenda.ToList();
            //inserindo produtoVenda no banco
            using (var dados = new DataAccess())
            {
                foreach (var produto in ProdutosVenda)
                {
                    dados.InsertProdutoVenda(produto);
                }
            }


            //inserindo Venda no BD
            using (var dados = new DataAccess())
            {

                dados.InsertVenda(Venda);
                //atualizar estoque

                foreach (var produto in Venda.Produtos)
                {

                    Model.Estoque estoque = null;

                    try
                    {
                        estoque = dados.GetEstoques().Where(c => c.Produto.IdProduto == produto.IdProduto).First();
                    }
                    catch (Exception ex)
                    {

                    }

                    if (estoque == null)
                    {
                        estoque = new Model.Estoque()
                        {
                            Quantidade = produto.Quantidade
                        };
                        estoque.Produto = dados.GetProdutos().Where(c => c.IdProduto == produto.IdProduto).First();
                        dados.InsertEstoque(estoque);
                    }
                    else
                    {
                        estoque.Quantidade -= produto.Quantidade;
                        dados.UpdateEstoque(estoque);
                    }
                }
            }
            await DisplayAlert("Mensagem", "Venda Cadastrada", "OK");
            await Navigation.PopAsync();
        }
    }
}
