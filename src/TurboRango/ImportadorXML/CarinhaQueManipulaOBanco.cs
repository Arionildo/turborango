using ConsoleApplication1;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ImportadorXML
{
    public class CarinhaQueManipulaOBanco
    {
        private string connectionString;

        public CarinhaQueManipulaOBanco(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void Inserir(Contato contato)
        {
            string comandoSQL = "INSERT INTO [dbo].[Contato] ([Site],[Telefone]) VALUES (@Site,@Telefone)";
            
            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var inserirContato = new SqlCommand(comandoSQL, connection))
                {
                    inserirContato.Parameters.Add("@Site", SqlDbType.NVarChar).Value = contato.Site;
                    inserirContato.Parameters.Add("@Telefone", SqlDbType.NVarChar).Value = contato.Telefone;

                    connection.Open();
                    int resultado = inserirContato.ExecuteNonQuery();
                }                    
            }
        }

        internal IEnumerable<Contato> GetContatos()
        {
            string comandoSQL = "SELECT [Site],[Telefone] FROM [dbo].[Contato]";

            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var lerContatos = new SqlCommand(comandoSQL, connection))
                {
                    connection.Open();
                    var leitor = lerContatos.ExecuteReader();

                    while (leitor.Read())
                    {
                        string site = leitor.GetString(0);
                        string telefone = leitor.GetString(1);
                    }
                }
            }

            return null; //CONTINUAR
        }
    }
}
