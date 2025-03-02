using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto // Classe que representa um produto no banco de dados
    {
        [PrimaryKey, AutoIncrement] // Define que o Id será a chave primária e será auto incrementado
        public int Id { get; set; }

        public string Descricao { get; set; } // Nome ou descrição do produto

        public double Quantidade { get; set; } // Quantidade disponível no estoque

        public double Preco { get; set; } // Preço do produto


    }
}
