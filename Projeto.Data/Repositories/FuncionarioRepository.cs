using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Data.Entities;
using Projeto.Data.Contracts;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace Projeto.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly string connectionString;

        public FuncionarioRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["aula"].ConnectionString;
        }
        public void Delete(int id)
        {
            string query = "delete from Funcionario where IdFuncionario=@IdFuncionario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new { IdFuncionario = id });
            }
        }

        public void Insert(Funcionario obj)
        {
            string query = "insert into Funcionario(Nome, Cpf, Salario, DataAdmissao) "
                            + "values(@Nome, @Cpf, @Salario, @DataAdmissao)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Funcionario> SelectAll()
        {
            string query = "select * from Funcionario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

        public Funcionario SelectById(int id)
        {
            string query = "select * from Funcionario where IdFuncionario = @IdFuncionario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query, new { IdFuncionario = id }).SingleOrDefault();
            }
        }

        public void Update(Funcionario obj)
        {
            string query = "update Funcionario set Nome=@Nome, Cpf=@Cpf, Salario=@Salario, "
                            + "DataAdmissao=@DataAdmissao where IdFuncionario=@IdFuncionario";
    
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public Funcionario SelectByCpf(string cpf)
        {
            string query = "select * from Funcionario where Cpf = @Cpf";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query, new { Cpf = cpf }).SingleOrDefault();
            }
        }
    }
}
