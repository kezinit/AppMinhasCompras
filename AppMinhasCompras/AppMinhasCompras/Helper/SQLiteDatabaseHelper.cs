using System;
using System.Collections.Generic;
using System.Text;


using AppMinhasCompras.Model;
using SQLite;
using System.Threading.Tasks;

namespace AppMinhasCompras.Helper
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public SQLiteDataBaseHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Save(Produto t)
        {
            return _connection.InsertAsync(t);
        }

        public Task<List<Produto>> GetAllRows()
        {
            return _connection.Table<Produto>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _connection.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> Update(Produto t)
        {
            string sql = "UPDATE produto SET " +
                         "Descricao=?, Preco=?, Quantidade=? " +
                         "WHERE Id=?";

            return _connection.QueryAsync<Produto>(sql,
                t.Descricao, t.Preco, t.Quantidade, t.Id);
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM produto WHERE Descricao LIKE '%" + q + "%'";

            return _connection.QueryAsync<Produto>(sql);
        }
    }
}
