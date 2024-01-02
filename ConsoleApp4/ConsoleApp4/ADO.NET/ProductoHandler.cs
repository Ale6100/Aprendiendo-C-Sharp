using System.Data;
using System.Data.SqlClient; // Instalar el paquete NuGet "System.Data.SqlClient". Al momento de escribir esto, se usa la versión 4.8.5

namespace EjemploDeClase
{
    internal class ProductoHandler : DbHandler
    {
        public Producto? GetById(int id)
        {
            Producto? producto = null;

            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using(SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Producto WHERE id = @id;";

                    sqlCommand.Parameters.AddWithValue("@id", id);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;

                    DataTable table = new DataTable();

                    dataAdapter.Fill(table); // Se ejecuta el SELECT y se llena el DataTable

                    sqlCommand.Connection.Close();

                    foreach (DataRow row in table.Rows)
                    {
                        producto = new Producto
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Descripciones = Convert.ToString(row["descripciones"]) ?? "",
                            Costo = Convert.ToDouble(row["costo"]),
                            PrecioVenta = Convert.ToDouble(row["precioVenta"]),
                            Stock = Convert.ToInt32(row["stock"]),
                            IdUsuario = Convert.ToInt32(row["idUsuario"])
                        };
                    }
                }
            }

            return producto;
        }
    }
}
