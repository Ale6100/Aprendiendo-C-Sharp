using ASP.NET_CoreWebAPI1.Model;
using System.Data;
using System.Data.SqlClient;

namespace ASP.NET_CoreWebAPI1.Repository
{
    public static class ProductoHandler
    {
        public const string ConnectionString = "Server=.\\SQLEXPRESS;" +
            "Database=AleP;" +
            "Trusted_Connection=True";

        public static List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Producto";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = sqlCommand;

                    DataTable table = new DataTable();
                    sqlDataAdapter.Fill(table);

                    sqlCommand.Connection.Close();

                    foreach (DataRow row in table.Rows)
                    {
                        Producto producto = new Producto();

                        producto.Id = Convert.ToInt32(row["id"]);
                        producto.Descripciones = Convert.ToString(row["descripciones"]);
                        producto.Costo = Convert.ToInt32(row["costo"]);
                        producto.PrecioVenta = Convert.ToInt32(row["precioVenta"]);
                        producto.Stock = Convert.ToInt32(row["stock"]);
                        producto.IdUsario = Convert.ToInt32(row["idUsuario"]);

                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }
    }
}
