using ApiTarefas2.Database;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MySql.Data.MySqlClient;

namespace ApiTarefas2.Models
{
    public class TarefaDAO
    {
        private static ConnectionMysql conn;

        public TarefaDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Tarefa item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO tarefas (descricao_tar, data_tar) VALUES (@descricao, @data)";

                query.Parameters.AddWithValue("@descricao", item.Descricao);
                query.Parameters.AddWithValue("@data", item.Data.ToString("yyyy-MM-dd HH:mm:ss")); //"10/11/1990" -> "1990-11-10"


                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

                return (int) query.LastInsertedId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Tarefa> List()
        {
            try
            {
                List<Tarefa> list = new List<Tarefa>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM tarefas";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Tarefa()
                    {
                        Id = reader.GetInt32("id_tar"),
                        Descricao = reader.GetString("descricao_tar"),
                        Data = reader.GetDateTime("data_tar"),
                        Feito = reader.GetBoolean("feito_tar")
                    });
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public Tarefa GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Tarefa Update(Tarefa item)
        {
            throw new NotImplementedException();
        }

        public Tarefa Delete(Tarefa item)
        {
            throw new NotImplementedException();
        }




    }
}
