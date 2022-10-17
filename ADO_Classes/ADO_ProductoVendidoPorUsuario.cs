
using Controllers;
using System.Data;
using System.Data.SqlClient;
using static Controllers.ProductoVendidoPorUsuarioController;


namespace ADO_Classes

{
    public class ADO_ProductoVendidoPorUsuario
    {

        public static List<ProductoVendidoPorUsuarioController> DevolverProductoVendidoPorUser(int idUsuario)
        {
            var listaProducto2 = new List<ProductoVendidoPorUsuarioController>();
            
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
                        
                        var producto2 = new ProductoVendidoPorUsuarioController();

                        producto2.IdVenta = Convert.ToInt32(reader2.GetValue(0));
                        producto2.IdProducto = Convert.ToInt32(reader2.GetValue(1));
                        producto2.Stock = Convert.ToInt32(reader2.GetValue(2));
                        producto2.Descripciones = reader2.GetValue(3).ToString();
                        producto2.PrecioVenta = Convert.ToDouble(reader2.GetValue(4));
                        producto2.IdUsuario = Convert.ToInt32(reader2.GetValue(5));


                        listaProducto2.Add(producto2);

                    }
                    Console.WriteLine();
                    Console.WriteLine("---- Informacion Productos vendidos por IdUsuario: {0}",idUsuario);
                    foreach (var datUser in listaProducto2)
                    {
                        Console.WriteLine("Id Venta es = " + datUser.IdVenta);
                        Console.WriteLine("Id Producto = " + datUser.IdProducto);
                        Console.WriteLine("Stock = " + datUser.Stock);
                        Console.WriteLine("Descripciones = " + datUser.Descripciones);
                        Console.WriteLine("Precio Venta = " + datUser.PrecioVenta);
                        Console.WriteLine("IdUsuario = " + datUser.IdUsuario);
                        Console.WriteLine("--------------");

                    }

                    reader2.Close();
                    connection.Close();


                    return listaProducto2;


                }
            }
        }
    }
}



//foreach (var idUser in listaProducto2)
//{

//    Console.WriteLine(idUser.ToString());

//    //Console.WriteLine(listaProducto2.ToString());
//    //Console.WriteLine(listaProducto2);
//    SqlCommand cmd3 = connection.CreateCommand();
//    cmd2.CommandText = "SELECT * FROM ProductoVendido where IdProducto = @idPrd";

//    var parametro2 = new SqlParameter();
//    parametro.ParameterName = "idPrd";
//    parametro.SqlDbType = SqlDbType.BigInt;
//    parametro.Value = idUser;

//    cmd2.Parameters.Add(parametro);

//    var reader3 = cmd3.ExecuteReader();

//    while (reader3.Read())
//    {
//        var producto2 = new ProductoVendidoPorUsuario();

//        producto2.IdVenta = Convert.ToInt32(reader3.GetValue(0));
//        producto2.IdProducto = Convert.ToInt32(reader3.GetValue(1));
//        producto2.Stock = Convert.ToInt32(reader3.GetValue(2));
//        producto2.Descripciones = reader2.GetValue(3).ToString();
//        producto2.PrecioVenta = Convert.ToDouble(reader3.GetValue(4));



//        listaProducto3.Add(producto2);



//    }