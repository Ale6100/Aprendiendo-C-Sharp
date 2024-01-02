using System.Data;
using System.Data.SqlClient; // Instalar el paquete NuGet "System.Data.SqlClient". Al momento de escribir esto, se usa la versión 4.8.5
namespace Connection
{
    public class Usuario // Objeto que representará a cada usuario de la base de datos
    {
        public int id { get; set; }
        public string name { get; set; }
        public int dni { get; set; }
    }

    public class ProductoHandler
    {

        public const string ConecctionString = "Server=.\\SQLEXPRESS;" +
            "Database=AleP;" +
            "Trusted_Connection=True";

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> res = [];

            using (SqlConnection sqlConnection = new SqlConnection(ConecctionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuarios", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.id = Convert.ToInt32(dataReader["id"]);
                                usuario.name = Convert.ToString(dataReader["name"]) ?? ""; // En caso de que el campo sea null, se le asigna un string vacío
                                usuario.dni = Convert.ToInt32(dataReader["dni"]);
                                res.Add(usuario);
                            }
                        }
                    }
                }
            }

            return res;
        }

        public List<int> MostrarUnaColumnaIntConDataReader()
        {
            List<int> res = new List<int>();
            using (SqlConnection sqlConnection = new SqlConnection(ConecctionString))
            {
                // using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuarios WHERE id=@id", sqlConnection))
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuarios WHERE id=1", sqlConnection))
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuarios", sqlConnection))
                {
                    // int id = 3;
                    sqlConnection.Open();
                    Console.WriteLine("Conectado :D");
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows) // Preguntamos si hay filas para leer
                        {
                            while (dataReader.Read()) // Mientras haya datos por recuperar ("Mientras haya cosas para mostrarme"). Itera sobre las filas devueltas
                            {
                                // var dato = dataReader.GetString(2) // Para devolver la columna 2, siempre y cuando sea un string
                                var dato = dataReader.GetInt32(2); // Para devolver la columna 2, siempre y cuando sea un int32
                                res.Add(dato);
                            }
                        }
                    }
                    // SqlParameter parametro = new SqlParameter
                    // {
                    //     ParameterName = "id", // Debe coincidir con el @ del SqlCommand
                    //     SqlDbType = System.Data.SqlDbType.Int,
                    //     Value = id
                    // };
                    // sqlCommand.Parameters.Add(parametro);
                    // sqlConnection.Close(); // Al instanciarlo con using, no es necesario el Close ya que se cierra automáticamente
                };
            };
            return res;
        }

        public List<int> MostrarUnaColumnaIntConDataAdapter()
        {
            List<int> res = new List<int>();
            using (SqlConnection sqlConnection = new SqlConnection(ConecctionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Usuarios", sqlConnection);

                sqlConnection.Open();

                DataSet resultado = new DataSet();
                sqlDataAdapter.Fill(resultado, "Usuarios"); // Acá se hace el llamado a la base de datos | sqlDataAdapter.Fill(resultado, "Usuarios");

            };
            return res;
        }
    }
}
