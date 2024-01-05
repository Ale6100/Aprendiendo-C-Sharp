using ASP.NET_CoreWebAPI1.Model;
using System.Data;
using System.Data.SqlClient;

namespace ASP.NET_CoreWebAPI1.Repository
{
    public static class UsuarioHandler
    {
        public const string ConnectionString = "Server=.\\SQLEXPRESS;" +
            "Database=AleP;" +
            "Trusted_Connection=True";

        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["id"]);
                                usuario.Nombre = Convert.ToString(dataReader["nombre"]);
                                usuario.Apellido = Convert.ToString(dataReader["apellido"]);
                                usuario.Contrasenia = Convert.ToInt32(dataReader["contrasenia"]);
                                usuario.NombreUsuario = Convert.ToString(dataReader["nombreUsuario"]);
                                usuario.Mail = Convert.ToString(dataReader["mail"]);

                                usuarios.Add(usuario);

                            }
                        }
                    }

                }
            }

            return usuarios;
        }

        public static bool EliminarUsuario(int id)
        {
            bool resultado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Usuario WHERE Id = @id";

                SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);
                sqlParameter.Value = id;
                
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }

        public static bool CrearUsuario(Usuario usuario)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO Usuario (nombre, apellido, contrasenia, nombreUsuario, mail)" +
                        "VALUES (@name, @lastname, @password, @username, @mail)";

                    SqlParameter name = new SqlParameter();
                    name.ParameterName = "name";
                    name.SqlDbType = SqlDbType.VarChar;
                    name.Value = usuario.Nombre;

                    SqlParameter lastname = new SqlParameter();
                    lastname.ParameterName = "lastname";
                    lastname.SqlDbType = SqlDbType.VarChar;
                    lastname.Value = usuario.Apellido;

                    SqlParameter password = new SqlParameter();
                    password.ParameterName = "password";
                    password.SqlDbType = SqlDbType.Int;
                    password.Value = usuario.Contrasenia;

                    SqlParameter username = new SqlParameter();
                    username.ParameterName = "username";
                    username.SqlDbType = SqlDbType.VarChar;
                    username.Value = usuario.NombreUsuario;

                    SqlParameter mail = new SqlParameter();
                    mail.ParameterName = "mail";
                    mail.SqlDbType = SqlDbType.VarChar;
                    mail.Value = usuario.Mail;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(name);
                        sqlCommand.Parameters.Add(lastname);
                        sqlCommand.Parameters.Add(password);
                        sqlCommand.Parameters.Add(username);
                        sqlCommand.Parameters.Add(mail);

                        int numberOfRows = sqlCommand.ExecuteNonQuery(); // Se ejecuta el INSERT

                        if (numberOfRows > 0)
                        {
                            resultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return resultado;

        }

        public static bool ModificarContraseniaUsuario(int id, int password)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryUpdate = "UPDATE Usuario SET contrasenia = @nuevaContrasenia WHERE id = @idUsuario";

                    SqlParameter idUsuario = new SqlParameter();
                    idUsuario.ParameterName = "idUsuario";
                    idUsuario.SqlDbType = SqlDbType.Int;
                    idUsuario.Value = id;

                    SqlParameter nuevaContrasenia = new SqlParameter();
                    nuevaContrasenia.ParameterName = "nuevaContrasenia";
                    nuevaContrasenia.SqlDbType = SqlDbType.Int;
                    nuevaContrasenia.Value = password;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(idUsuario);
                        sqlCommand.Parameters.Add(nuevaContrasenia);

                        int numberOfRows = sqlCommand.ExecuteNonQuery(); // Se ejecuta el UPDATE

                        if (numberOfRows > 0)
                        {
                            resultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return resultado;
        }
    }
}
