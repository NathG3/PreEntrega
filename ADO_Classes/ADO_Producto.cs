
using ConsoleApp.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Classes

{
    public class ADO_Producto
    {

        public static List<Producto> DevolverProducto(int idUsuario)
        {
            var listaProducto = new List<Producto>();


            {
                SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
                conecctionbuilder.DataSource = "LAPTOP-OV95KCR8";
                conecctionbuilder.InitialCatalog = "SistemaGestion";
                conecctionbuilder.IntegratedSecurity = true;
                var cs = conecctionbuilder.ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {

                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Producto where IdUsuario = @idUs";

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idUs";
                    parametro.SqlDbType = SqlDbType.BigInt;
                    parametro.Value = idUsuario;

                    cmd.Parameters.Add(parametro);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var producto = new Producto();

                        producto.Id = Convert.ToInt32(reader.GetValue(0));
                        producto.Descripciones = reader.GetValue(1).ToString();
                        producto.Costo = Convert.ToDouble(reader.GetValue(2));
                        producto.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                        producto.Stock = Convert.ToInt32(reader.GetValue(4));
                        producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                        listaProducto.Add(producto);

                    }

                    reader.Close();
                    connection.Close();

                    return listaProducto;

                }
            }
        }
    }
}

