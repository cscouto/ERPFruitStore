using AppLoja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLoja.Pages.Compra
{
    public partial class CompraPage : ContentPage
    {
        Model.Compra compra;

        IList<Model.Fornecedor> Fornecedores = new List<Model.Fornecedor>();
        IList<Model.Produto> Produtos = new List<Model.Produto>();
        IList<Model.ProdutoCompra> ProdutosNota = new List<Model.ProdutoCompra>();

        public CompraPage()
        {
            InitializeComponent();

            //incializa compra
            compra = new Model.Compra();

            //recebendo dados
            using(var dados = new DataAccess())
            {
                Produtos = dados.GetProdutos();
                Fornecedores = dados.GetFornecedors();
            }
            
            //iniciando ComboBoxs
            foreach(var produto in Produtos)
            {
                PickerProduto.Items.Add(produto.ToString());
            }

            foreach(var fornecedor in Fornecedores)
            {
                PickerFornecedor.Items.Add(fornecedor.ToString());
            }

            //button add produto
            ButtonAdd.Clicked += ButtonAdd_Clicked;

            //button salvar
            ButtonSalvar.Clicked += ButtonSalvar_Clicked;

            //modelo da listview
            lvProdutos.ItemTemplate = new DataTemplate(typeof(ProdutoNotaCell));
        }

        private void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            PickerFornecedor.IsEnabled = false;
            DatePickerCompra.IsEnabled = false;

            //produto selecionado no picker
            var produto = Produtos.Where(p => p.Descricao == PickerProduto.Items[PickerProduto.SelectedIndex]).First();
            
            //cria novo produto nota
            ProdutoCompra produtoNota = new ProdutoCompra()
            {

                Produto = produto,
                Quantidade = Convert.ToInt32(EntryQuantidade.Text),
                Preco = Convert.ToDouble(EntryValorUnit.Text),
            };

            //armazenando produtosNota
            ProdutosNota.Add(produtoNota);


            //ativa botao salvar
            ButtonSalvar.IsEnabled = true;

            //limpa dados
            PickerProduto.SelectedIndex = -1;
            EntryQuantidade.Text = string.Empty;
            EntryValorUnit.Text = string.Empty;

            //calcula o total
            if (!lbValorTotal.Equals(string.Empty))
            {
                lbValorTotal.Text = (Convert.ToDouble(lbValorTotal.Text) + (produtoNota.Quantidade * produtoNota.Preco)).ToString();
            }
            else
            {
                lbValorTotal.Text = (produtoNota.Quantidade * produtoNota.Preco).ToString();
            }

            lvProdutos.ItemsSource = null;

            lvProdutos.ItemsSource = ProdutosNota;

        }

        private async void ButtonSalvar_Clicked(object sender, EventArgs e)
        {
            var fornecedor = Fornecedores.Where(p => p.Descricao == PickerFornecedor.Items[PickerFornecedor.SelectedIndex]).First();
            
            //dados para compra
            compra.Fornecedor = fornecedor;
            compra.DataCompra = String.Format("{0:d}", DatePickerCompra.Date);
            compra.ValorTotal = Convert.ToDouble(lbValorTotal.Text);

            compra.Produtos = ProdutosNota.ToList();
            //inserindo produtoNota no banco
            using (var dados = new DataAccess())
            {
                foreach (var produto in ProdutosNota)
                {
                    dados.InsertProdutoNota(produto);
                }
            }
            

            //inserindo compra no BD
            using (var dados = new DataAccess())
            {
                
                dados.InsertCompra(compra);
                //atualizar estoque

                foreach (var produto in compra.Produtos)
                {
                   
                    Model.Estoque estoque = null;

                    try
                    {
                        estoque = dados.GetEstoques().Where(c => c.Produto.IdProduto == produto.IdProduto).First();
                    }catch(Exception ex)
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
                    }else
                    {
                        estoque.Quantidade += produto.Quantidade;
                        dados.UpdateEstoque(estoque);
                    }
                }
            }
            await DisplayAlert("Mensagem", "Compra Cadastrada", "OK");
            await Navigation.PopAsync();
        }
    }
}
