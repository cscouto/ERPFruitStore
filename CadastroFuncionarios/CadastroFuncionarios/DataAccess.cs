using AppLoja.Model;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLoja
{
    class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IDataBase>();
            connection = new SQLiteConnection(config.Plataforma,
                Path.Combine(config.DiretorioDB, "Loja.db3"));
            connection.CreateTable<Estoque>();
            connection.CreateTable<Fornecedor>();
            connection.CreateTable<Produto>();
            connection.CreateTable<Compra>();
            connection.CreateTable<Venda>();
            connection.CreateTable<ProdutoCompra>();
            connection.CreateTable<ProdutoVenda>();
        }

        public void InsertProduto(Produto produto)
        {
            connection.Insert(produto);
        }

        public void UpdateProduto(Produto produto)
        {
            connection.Update(produto);
        }

        public void DeleteProduto(Produto produto)
        {
            connection.Delete(produto);
        }

        public Produto GetProduto(int IDProduto)
        {
            return connection.Table<Produto>().FirstOrDefault(c => c.IdProduto == IDProduto);
        }

        public List<Produto> GetProdutos()
        {
            return connection.Table<Produto>().OrderBy(c => c.IdProduto).ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
        public void InsertFornecedor(Fornecedor fornecedor)
        {
            connection.Insert(fornecedor);
        }

        public void UpdateFornecedor(Fornecedor fornecedor)
        {
            connection.Update(fornecedor);
        }

        public void DeleteFornecedor(Fornecedor fornecedor)
        {
            connection.Delete(fornecedor);
        }

        public Fornecedor GetFornecedor(int IDFornecedor)
        {
            return connection.Table<Fornecedor>().FirstOrDefault(c => c.IdFornecedor == IDFornecedor);
        }

        public List<Fornecedor> GetFornecedors()
        {
            return connection.Table<Fornecedor>().OrderBy(c => c.IdFornecedor).ToList();
        }

        public void InsertCompra(Compra compra)
        {
           // connection.Insert(compra);
            connection.InsertWithChildren(compra);
        }

        public void UpdateCompra(Compra compra)
        {
            connection.UpdateWithChildren(compra);
        }

        public void DeleteCompra(Compra compra)
        {
            connection.Delete(compra);
        }

        public Compra GetCompra(int IDCompra)
        {
            return connection.GetAllWithChildren<Compra>().FirstOrDefault(c => c.IdCompra == IDCompra);
        }

        public List<Compra> GetCompras()
        {
            return connection.GetAllWithChildren<Compra>().OrderBy(c => c.IdCompra).ToList();
        }

        public void InsertVenda(Venda Venda)
        {
            // connection.Insert(Venda);
            connection.InsertWithChildren(Venda);
        }

        public void UpdateVenda(Venda Venda)
        {
            connection.UpdateWithChildren(Venda);
        }

        public void DeleteVenda(Venda Venda)
        {
            connection.Delete(Venda);
        }

        public Venda GetVenda(int IDVenda)
        {
            return connection.GetAllWithChildren<Venda>().FirstOrDefault(c => c.IdVenda == IDVenda);
        }

        public List<Venda> GetVendas()
        {
            return connection.GetAllWithChildren<Venda>().OrderBy(c => c.IdVenda).ToList();
        }

        public void InsertEstoque(Estoque estoque)
        {
            connection.InsertWithChildren(estoque);
        }

        public void UpdateEstoque(Estoque estoque)
        {
            connection.UpdateWithChildren(estoque);
        }

        public void DeleteEstoque(Estoque estoque)
        {
            connection.Delete(estoque);
        }

        public Estoque GetEstoque(int IDEstoque)
        {
            return connection.GetAllWithChildren<Estoque>().FirstOrDefault(c => c.IdEstoque == IDEstoque);
        }

        public List<Estoque> GetEstoques()
        {
            return connection.GetAllWithChildren<Estoque>().OrderBy(c => c.IdEstoque).ToList();
        }

        public void InsertProdutoNota(ProdutoCompra ProdutoNota)
        {
            connection.InsertWithChildren(ProdutoNota);
        }

        public void UpdateProdutoNota(ProdutoCompra ProdutoNota)
        {
            connection.UpdateWithChildren(ProdutoNota);
        }

        public void ProdutoNota(ProdutoCompra ProdutoNota)
        {
            connection.Delete(ProdutoNota);
        }

        public ProdutoCompra GetProdutoNota(int IDProdutoNota)
        {
            return connection.GetAllWithChildren<ProdutoCompra>().FirstOrDefault(c => c.IdProdutoCompra == IDProdutoNota);
        }

        public List<ProdutoCompra> GetProdutoNotas()
        {
            return connection.GetAllWithChildren<ProdutoCompra>().OrderBy(c => c.IdProdutoCompra).ToList();
        }
        public void InsertProdutoVenda(ProdutoVenda ProdutoVenda)
        {
            connection.InsertWithChildren(ProdutoVenda);
        }

        public void UpdateProdutoVenda(ProdutoVenda ProdutoVenda)
        {
            connection.UpdateWithChildren(ProdutoVenda);
        }

        public void ProdutoVenda(ProdutoVenda ProdutoVenda)
        {
            connection.Delete(ProdutoVenda);
        }

        public ProdutoVenda GetProdutoVenda(int IDProdutoVenda)
        {
            return connection.GetAllWithChildren<ProdutoVenda>().FirstOrDefault(c => c.IdProdutoVenda == IDProdutoVenda);
        }

        public List<ProdutoVenda> GetProdutoVendas()
        {
            return connection.GetAllWithChildren<ProdutoVenda>().OrderBy(c => c.IdProdutoVenda).ToList();
        }
    }
}
