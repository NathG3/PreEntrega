
using ConsoleApp.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Classes

{
    public class ADO_ProductoVendidoPorUsuario
    {

        public static List<ProductoVendidoPorUsuario> DevolverProductoVendidoPorUser(int idUsuario)
        {
            var listaProducto2 = new List<ProductoVendidoPorUsuario>();
            
            string cmdString = "SELECT pv.IdVenta, pv.IdProducto, pv.Stock, pr.Descripciones, " +
                "pr.PrecioVenta, pr.IdUsuario FROM ProductoVendido as pv inner join Producto " +
                "as pr ON pv.IdProducto = pr.Id WHERE IdUsuario = @idUsu";
            {
                SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
                conecctionbuilder.DataSource = "LAPTOP-OV95KCR8";
                conecctionbuilder.InitialCatalog = "SistemaGestion";
                conecctionbuilder.IntegratedSecurity = true;
                var cs = conecctionbuilder.ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd2 = connection.CreateCommand();
           
                    cmd2.CommandText = cmdString;

                    var parametro2 = new SqlParameter();
                    parametro2.ParameterName = "idUsu";
                    parametro2.SqlDbType = SqlDbType.BigInt;
                    parametro2.Value = idUsuario;

                    cmd2.Parameters.Add(parametro2);

                    var reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        
                        var producto2 = new ProductoVendidoPorUsuario();

                        producto2.IdVenta = Convert.ToInt32(reader2.GetValue(0));
                        producto2.IdProducto = Convert.ToInt32(reader2.GetValue(1));
                        producto2.Stock = Convert.ToInt32(reader2.GetValue(2));
                        producto2.Descripciones = reader2.GetValue(3).ToString();
                        producto2.PrecioVenta = Convert.ToDouble(reader2.GetValue(4));
                        producto2.IdUsuario = Convert.ToInt32(reader2.GetValue(5));


                        listaProducto2.Add(producto2);

                    }

                    reader2.Close();
                    connection.Close();


                    return listaProducto2;


                }
            }
        }
    }
}
