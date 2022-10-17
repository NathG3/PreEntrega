
using Controllers;
using System.Data;
using System.Data.SqlClient;
using static Controllers.VentaController;


namespace ADO_Classes

{
    public class ADO_Venta
    {

        public static List<Venta> TraerVentaPorUsuario(int idUsuario)
        {
            var listaVentas = new List<Venta>();


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
                    cmd.CommandText = "SELECT * FROM Venta where IdUsuario = @idUs";

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idUs";
                    parametro.SqlDbType = SqlDbType.BigInt;
                    parametro.Value = idUsuario;

                    cmd.Parameters.Add(parametro);

                    var reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        var venta = new Venta();

                        venta.Id = Convert.ToInt32(reader3.GetValue(0));
                        venta.Comentarios = reader3.GetValue(1).ToString();
                        venta.IdUsuario = Convert.ToInt32(reader3.GetValue(2));

                        listaVentas.Add(venta);

                    }
                    Console.WriteLine();
                    Console.WriteLine("---- Informacion venta IdUsuario: {0} ", idUsuario);
                    foreach (var datVenta in listaVentas)
                    {
                        Console.WriteLine("Id del Venta= " + datVenta.Id);
                        Console.WriteLine("Comentarios = " + datVenta.Comentarios);
                        Console.WriteLine("IdUsuario = " + datVenta.IdUsuario);
                        Console.WriteLine("--------------");

                    }

                    reader3.Close();
                    connection.Close();

                    return listaVentas;

                }
            }
        }
    }
}

