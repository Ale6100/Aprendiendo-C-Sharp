using System.Data;
using System.Data.SqlClient;

namespace EjemploDeClase
{
    public class UsuarioHandler : DbHandler
    {
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString)) // Crea una nueva instancia de SqlConnection y establece la cadena de conexión a la base de dato
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows) // Nos aseguramos de que haya filas por leer
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario
                                {
                                    Id = Convert.ToInt32(dataReader["id"]),
                                    Nombre = Convert.ToString(dataReader["nombre"]) ?? "",
                                    Apellido = Convert.ToString(dataReader["apellido"]) ?? "",
                                    Contrasenia = Convert.ToInt32(dataReader["contrasenia"]),
                                    NombreUsuario = Convert.ToString(dataReader["nombreUsuario"]) ?? "",
                                    Mail = Convert.ToString(dataReader["mail"]) ?? ""
                                };

                                usuarios.Add(usuario);
                            }
                        }
                    }
                }
            }

            return usuarios;
        }

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM Usuario WHERE id = @idUsuario";

                    SqlParameter parametro = new SqlParameter();

                    parametro.ParameterName = "idUsuario";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = id;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametro);
                        return sqlCommand.ExecuteNonQuery(); // Se ejecuta el DELETE
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
            }
        }

        public int UpdateContrasenia(int id, int password)
        {
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
                        return sqlCommand.ExecuteNonQuery(); // Se ejecuta el UPDATE
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
            }
        }

        // public int Insert(string nombre, string apellido, int contrasenia, string nombreUsuario, string mail)
        public int Insert(Usuario usuario)
        {
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

                        return sqlCommand.ExecuteNonQuery(); // Se ejecuta el INSERT
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
            }
        }
    }
}
