using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper 
    {
        readonly SQLiteAsyncConnection _conn;

        // Construtor da classe que inicializa a conexão com o banco de dados
        public SQLiteDatabaseHelper(string path) {

            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        // Método para inserir um produto no banco de dados
        public Task<int> Insert(Produto p) 
        {
            return _conn.InsertAsync(p);
        }

        // Método para atualizar um produto no banco de dados
        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
                );
        }


        // Método para excluir um produto pelo ID
        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }


        // Método para obter todos os produtos cadastrados
        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();
        }


        // Método para buscar produtos pelo nome (Descrição)
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * Produto WHERE Descricao LIKE '%%'" + q + "'%'";

            return _conn.QueryAsync<Produto>(sql);
        }


    }

   
}

