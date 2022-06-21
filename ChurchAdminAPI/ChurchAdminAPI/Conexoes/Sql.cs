using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChurchAdminAPI.Conexoes
{
    public class Sql
    {
        private readonly SqlConnection _conexao;

        public Sql()
        {
            string conexao = "Server=5.161.71.7;Database=DB_ChurchAdmin;User Id =Meriane;Password='{6qky>\\&`>'";
            this._conexao = new SqlConnection(conexao);
        }


        //Membro
        public void CadastrarMembro(Models.Membro membro)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Membro
                               (Cpf,
                                Nome,
                                Cep,
                                Endereco,
                                Numero,
                                Complemento,
                                Bairro,
                                Municipio,
                                Estado,
                                Email,
                                Fone,
                                Sexo,
                                Nascimento,
                                Naturalidade,
                                EstadoCivil,
                                Profissao,
                                DataBatismoAguas,
                                CargoIgreja,
                                IgrejaID,
                                Status)
                               VALUES
                                (@Cpf,
                                @Nome,
                                @Cep,
                                @Endereco,
                                @Numero,
                                @Complemento,
                                @Bairro,
                                @Municipio,
                                @Estado,
                                @Email,
                                @Fone,
                                @Sexo,
                                @Nascimento,
                                @Naturalidade,
                                @EstadoCivil,
                                @Profissao,
                                @DataBatismoAguas,
                                @CargoIgreja,
                                @IgrejaID,
                                @Status);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Cpf", String.IsNullOrEmpty(membro.Cpf) ? DBNull.Value : membro.Cpf);

                    cmd.Parameters.AddWithValue("Nome", String.IsNullOrEmpty(membro.Nome) ? DBNull.Value : membro.Nome);

                    cmd.Parameters.AddWithValue("Cep", String.IsNullOrEmpty(membro.Cep) ? DBNull.Value : membro.Cep);

                    cmd.Parameters.AddWithValue("Endereco", String.IsNullOrEmpty(membro.Endereco) ? DBNull.Value : membro.Endereco);

                    cmd.Parameters.AddWithValue("Numero", String.IsNullOrEmpty(membro.Numero.ToString()) ? DBNull.Value : membro.Numero);

                    cmd.Parameters.AddWithValue("Complemento", String.IsNullOrEmpty(membro.Complemento) ? DBNull.Value : membro.Complemento);
               
                    cmd.Parameters.AddWithValue("Bairro", String.IsNullOrEmpty(membro.Bairro) ? DBNull.Value : membro.Bairro);

                    cmd.Parameters.AddWithValue("Municipio", String.IsNullOrEmpty(membro.Municipio) ? DBNull.Value : membro.Municipio);

                    cmd.Parameters.AddWithValue("Estado", String.IsNullOrEmpty(membro.Estado) ? DBNull.Value : membro.Estado);

                    cmd.Parameters.AddWithValue("Email", String.IsNullOrEmpty(membro.Email) ? DBNull.Value : membro.Email);

                    cmd.Parameters.AddWithValue("Fone", String.IsNullOrEmpty(membro.Fone) ? DBNull.Value : membro.Fone);

                    cmd.Parameters.AddWithValue("Sexo", String.IsNullOrEmpty(membro.Sexo.ToString()) ? DBNull.Value : membro.Sexo);

                    cmd.Parameters.AddWithValue("Nascimento", String.IsNullOrEmpty(membro.Nascimento) ? DBNull.Value : membro.Nascimento);

                    cmd.Parameters.AddWithValue("Naturalidade", String.IsNullOrEmpty(membro.Naturalidade) ? DBNull.Value : membro.Naturalidade);
         
                    cmd.Parameters.AddWithValue("EstadoCivil", String.IsNullOrEmpty(membro.EstadoCivil) ? DBNull.Value : membro.EstadoCivil);

                    cmd.Parameters.AddWithValue("Profissao", String.IsNullOrEmpty(membro.Profissao) ? DBNull.Value : membro.Profissao);

                    cmd.Parameters.AddWithValue("DataBatismoAguas", String.IsNullOrEmpty(membro.DataBatismoAguas) ? DBNull.Value : membro.DataBatismoAguas);
                  
                    cmd.Parameters.AddWithValue("CargoIgreja", String.IsNullOrEmpty(membro.CargoIgreja) ? DBNull.Value : membro.CargoIgreja);

                    cmd.Parameters.AddWithValue("IgrejaID", String.IsNullOrEmpty(membro.IgrejaID.ToString()) ? DBNull.Value : membro.IgrejaID);
               
                    cmd.Parameters.AddWithValue("Status", String.IsNullOrEmpty(membro.Status.ToString()) ? DBNull.Value : membro.Status);

                    cmd.ExecuteNonQuery();
                }

            }
            finally
            {
                _conexao.Close();
            }
        }

        public void AtualizarMembro(Models.Membro membro)
        {
            try
            {
                _conexao.Open();

                string sql = @"UPDATE Membro
                                SET 
                                Cpf = @Cpf,
                                Nome = @Nome,
                                Cep = @Cep ,
                                Endereco = @Endereco,
                                Numero = @Numero,
                                Complemento = @Complemento,
                                Bairro = @Bairro,
                                Municipio = @Municipio,
                                Estado = @Estado,
                                Email = @Email,
                                Fone = @Fone,
                                Sexo = @Sexo,
                                Nascimento = @Nascimento,
                                Naturalidade = @Naturalidade,
                                EstadoCivil = @EstadoCivil,
                                Profissao = @Profissao,
                                DataBatismoAguas = @DataBatismoAguas,
                                CargoIgreja = @CargoIgreja,
                                IgrejaID = @IgrejaID,
                                Status = @Status
                                WHERE Matricula = @Matricula";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Matricula", membro.Matricula);
                    cmd.Parameters.AddWithValue("Cpf", membro.Cpf);
                    cmd.Parameters.AddWithValue("Nome", membro.Nome);
                    cmd.Parameters.AddWithValue("Cep", membro.Cep);
                    cmd.Parameters.AddWithValue("Endereco", membro.Endereco);
                    cmd.Parameters.AddWithValue("Numero", membro.Numero);
                    cmd.Parameters.AddWithValue("Complemento", membro.Complemento);
                    cmd.Parameters.AddWithValue("Bairro", membro.Bairro);
                    cmd.Parameters.AddWithValue("Municipio", membro.Municipio);
                    cmd.Parameters.AddWithValue("Estado", membro.Estado);
                    cmd.Parameters.AddWithValue("Email", membro.Email);
                    cmd.Parameters.AddWithValue("Fone", membro.Fone);
                    cmd.Parameters.AddWithValue("Sexo", membro.Sexo);
                    cmd.Parameters.AddWithValue("Nascimento", membro.Nascimento);
                    cmd.Parameters.AddWithValue("Naturalidade", membro.Naturalidade);
                    cmd.Parameters.AddWithValue("EstadoCivil", membro.EstadoCivil);
                    cmd.Parameters.AddWithValue("Profissao", membro.Profissao);
                    cmd.Parameters.AddWithValue("DataBatismoAguas", membro.DataBatismoAguas);
                    cmd.Parameters.AddWithValue("CargoIgreja", membro.CargoIgreja);
                    cmd.Parameters.AddWithValue("IgrejaID", membro.IgrejaID);
                    cmd.Parameters.AddWithValue("Status", membro.Status);
                    cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new InvalidOperationException("O membro não foi atualizado!");
                    }

                }
            }
            finally
            {
                _conexao.Close();

            }
        }

        public void DeletarMembro(int matricula)
        {
            try
            {
                _conexao.Open();

                string sql = @"DELETE FROM Membro 
                               WHERE  Matricula = @Matricula";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("@Matricula", matricula);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new InvalidOperationException("Matrícula não encontrada!");
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<Models.Membro> ListarMembros()
        {
            var membros = new List<Models.Membro>();
            try
            {
                _conexao.Open();

                string sql = @"Select * FROM Membro";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var membro = new Models.Membro();

                        membro.Matricula = Convert.ToInt32(rdr["Matricula"]);
                        membro.Cpf = rdr["Cpf"].ToString();
                        membro.Nome = rdr["Nome"].ToString();
                        membro.Cep = rdr["Cep"].ToString();
                        membro.Endereco = rdr["Endereco"].ToString();
                        membro.Numero = String.IsNullOrEmpty(rdr["Numero"].ToString()) ? null : Convert.ToInt32(rdr["Numero"].ToString());
                        membro.Complemento = rdr["Complemento"].ToString();
                        membro.Bairro = rdr["Bairro"].ToString();
                        membro.Municipio = rdr["Municipio"].ToString();
                        membro.Estado = rdr["Estado"].ToString();
                        membro.Email = rdr["Email"].ToString();
                        membro.Fone = rdr["Fone"].ToString();
                        membro.Sexo = String.IsNullOrEmpty(rdr["Sexo"].ToString()) ? null : Convert.ToChar(rdr["Sexo"].ToString());
                        membro.Nascimento = rdr["Nascimento"].ToString();
                        membro.Naturalidade = rdr["Naturalidade"].ToString();
                        membro.EstadoCivil = rdr["EstadoCivil"].ToString();
                        membro.Profissao = rdr["Profissao"].ToString();
                        membro.DataBatismoAguas = rdr["DataBatismoAguas"].ToString();
                        membro.CargoIgreja = rdr["CargoIgreja"].ToString();
                        membro.IgrejaID = String.IsNullOrEmpty(rdr["IgrejaID"].ToString()) ? null : Convert.ToInt32(rdr["IgrejaID"].ToString());
                        membro.Status = String.IsNullOrEmpty(rdr["Status"].ToString()) ? null : Convert.ToBoolean(rdr["Status"].ToString());

                        membros.Add(membro);
                    }

                }
            }
            finally
            {
                _conexao.Close();
            }

            return membros;
        }




       //Igreja
        public void CadastrarIgreja(Models.Igreja igreja)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Igreja
                               (NomeIgreja, 
                                RazaoSocial, 
                                Cnpj, 
                                Cep, 
                                Endereco,
                                Numero, 
                                Complemento, 
                                Bairro, 
                                Municipio, 
                                Estado, 
                                Fone1, 
                                Fone2, 
                                Categoria, 
                                DataCadastro, 
                                DataFundacao, 
                                Email)
                               VALUES
                                (@NomeIgreja, 
                                @RazaoSocial, 
                                @Cnpj, 
                                @Cep, 
                                @Endereco, 
                                @Numero, 
                                @Complemento, 
                                @Bairro, 
                                @Municipio, 
                                @Estado, 
                                @Fone1, 
                                @Fone2, 
                                @Categoria, 
                                @DataCadastro, 
                                @DataFundacao, 
                                @Email);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("NomeIgreja", String.IsNullOrEmpty(igreja.NomeIgreja) ? DBNull.Value : igreja.NomeIgreja);

                    cmd.Parameters.AddWithValue("RazaoSocial", String.IsNullOrEmpty(igreja.RazaoSocial) ? DBNull.Value : igreja.RazaoSocial);

                    cmd.Parameters.AddWithValue("Cnpj", String.IsNullOrEmpty(igreja.Cnpj) ? DBNull.Value : igreja.Cnpj);

                    cmd.Parameters.AddWithValue("Cep", String.IsNullOrEmpty(igreja.Cep) ? DBNull.Value : igreja.Cep);

                    cmd.Parameters.AddWithValue("Endereco", String.IsNullOrEmpty(igreja.Endereco) ? DBNull.Value : igreja.Endereco);

                    cmd.Parameters.AddWithValue("Numero", String.IsNullOrEmpty(igreja.Numero.ToString()) ? DBNull.Value : igreja.Numero);

                    cmd.Parameters.AddWithValue("Complemento", String.IsNullOrEmpty(igreja.Complemento) ? DBNull.Value : igreja.Complemento);

                    cmd.Parameters.AddWithValue("Bairro", String.IsNullOrEmpty(igreja.Bairro) ? DBNull.Value : igreja.Bairro);

                    cmd.Parameters.AddWithValue("Municipio", String.IsNullOrEmpty(igreja.Municipio) ? DBNull.Value : igreja.Municipio);

                    cmd.Parameters.AddWithValue("Estado", String.IsNullOrEmpty(igreja.Estado) ? DBNull.Value : igreja.Estado);

                    cmd.Parameters.AddWithValue("Fone1", String.IsNullOrEmpty(igreja.Fone1) ? DBNull.Value : igreja.Fone1);

                    cmd.Parameters.AddWithValue("Fone2", String.IsNullOrEmpty(igreja.Fone2) ? DBNull.Value : igreja.Fone2);

                    cmd.Parameters.AddWithValue("Categoria", String.IsNullOrEmpty(igreja.Categoria) ? DBNull.Value : igreja.Categoria);

                    cmd.Parameters.AddWithValue("DataCadastro", String.IsNullOrEmpty(igreja.DataCadastro) ? DBNull.Value : igreja.DataCadastro);

                    cmd.Parameters.AddWithValue("DataFundacao", String.IsNullOrEmpty(igreja.DataFundacao) ? DBNull.Value : igreja.DataFundacao);

                    cmd.Parameters.AddWithValue("Email", String.IsNullOrEmpty(igreja.Email) ? DBNull.Value : igreja.Email);

                    cmd.ExecuteNonQuery();
                }
            }

            finally
            {
                _conexao.Close();
            }
        }

        public void AtualizarIgreja(Models.Igreja igreja)
        {
            try
            {
                _conexao.Open();

                string sql = @" UPDATE Igreja
                                SET NomeIgreja = @NomeIgreja,
                                RazaoSocial = @RazaoSocial,
                                Cnpj = @Cnpj,
                                Cep = @Cep,
                                Endereco = @Endereco,
                                Numero = @Numero,
                                Complemento = @Complemento,
                                Bairro = @Bairro,
                                Municipio = @Municipio,
                                Estado = @Estado,
                                Fone1 = @Fone1,
                                Fone2 = @Fone2,
                                Categoria = @Categoria,
                                DataCadastro = @DataCadastro,
                                DataFundacao = @DataFundacao,
                                Email = @Email
                                WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {

                    cmd.Parameters.AddWithValue("Id", igreja.Id);
                    cmd.Parameters.AddWithValue("NomeIgreja", igreja.NomeIgreja);
                    cmd.Parameters.AddWithValue("RazaoSocial", igreja.RazaoSocial);
                    cmd.Parameters.AddWithValue("Cnpj", igreja.Cnpj);
                    cmd.Parameters.AddWithValue("Cep", igreja.Cep);
                    cmd.Parameters.AddWithValue("Endereco", igreja.Endereco);
                    cmd.Parameters.AddWithValue("Numero", igreja.Numero);
                    cmd.Parameters.AddWithValue("Complemento", igreja.Complemento);
                    cmd.Parameters.AddWithValue("Bairro", igreja.Bairro);
                    cmd.Parameters.AddWithValue("Municipio", igreja.Municipio);
                    cmd.Parameters.AddWithValue("Estado", igreja.Estado);
                    cmd.Parameters.AddWithValue("Fone1", igreja.Fone1);
                    cmd.Parameters.AddWithValue("Fone2", igreja.Fone2);
                    cmd.Parameters.AddWithValue("Categoria", igreja.Categoria);
                    cmd.Parameters.AddWithValue("DataCadastro", igreja.DataCadastro);
                    cmd.Parameters.AddWithValue("DataFundacao", igreja.DataFundacao);
                    cmd.Parameters.AddWithValue("Email", igreja.Email);

                    cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new InvalidOperationException("O membro não foi atualizado!");
                    }

                }
            }
            finally
            {
                _conexao.Close();

            }
        }

        public void DeletarIgreja(int id)
        {
            try
            {
                _conexao.Open();

                string sql = @"DELETE FROM Igreja 
                               WHERE  Id = @Id";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new InvalidOperationException("Id não encontrado!");
                    }

                }

            }
            finally
            {
                _conexao.Close();
            }

        }

        public List<Models.Igreja> ListarIgrejas()
        {
            var igrejas = new List<Models.Igreja>();
            try
            {
                _conexao.Open();

                string sql = @"Select * FROM Igreja";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var igreja = new Models.Igreja();
                        igreja.Id = Convert.ToInt32(rdr["Id"].ToString());
                        igreja.NomeIgreja = rdr["NomeIgreja"].ToString();
                        igreja.RazaoSocial = rdr["RazaoSocial"].ToString();
                        igreja.Cnpj = rdr["Cnpj"].ToString();
                        igreja.Cep = rdr["Cep"].ToString();
                        igreja.Endereco = rdr["Endereco"].ToString();
                        igreja.Numero = String.IsNullOrEmpty(rdr["Numero"].ToString()) ? null : Convert.ToInt32(rdr["Numero"].ToString());
                        igreja.Complemento = rdr["Complemento"].ToString();
                        igreja.Bairro = rdr["Bairro"].ToString();
                        igreja.Municipio = rdr["Municipio"].ToString();
                        igreja.Estado = rdr["Estado"].ToString();
                        igreja.Fone1 = rdr["Fone1"].ToString();
                        igreja.Fone2 = rdr["Fone2"].ToString();
                        igreja.Categoria = rdr["Categoria"].ToString();
                        igreja.DataCadastro = rdr["DataCadastro"].ToString();
                        igreja.DataFundacao = rdr["DataFundacao"].ToString();
                        igreja.Email = rdr["Email"].ToString();


                        igrejas.Add(igreja);
                    }

                }
            }
            finally
            {
                _conexao.Close();
            }

            return igrejas;
        }
      


        //Usuario
        public Models.Usuario BuscarUsuario(string login, string senha)
        {
            try
            {
                _conexao.Open();

                string query = @"Select * FROM USUARIO
                                 WHERE login = @login
                                 AND senha = @senha";

                using (var cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        var usuario = new Models.Usuario();
                        usuario.Login = login;
                        usuario.Senha = rdr["senha"].ToString();

                        return usuario;
                    }
                    else
                    {
                        throw new InvalidOperationException("Email ou senha Inválidos!");
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }

        }

  
    }
}
