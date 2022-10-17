using System.Data;
using System.Data.SqlClient;
using static Controllers.UsuarioController;

namespace ADO_Classes
{
    public class ADO_InicioSesion
    {
        public static List<Usuario> InicioSesion()
        {
            var datosUsuario = new List<Usuario>();

            Console.WriteLine("Por favor ingrese el nombre de usuario:");
            string nombreUsu = Console.ReadLine();
            Console.WriteLine("Por favor ingrese la contraseña:");
            string contraseña = Console.ReadLine();

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
                    cmd.CommandText =
                        "SELECT * FROM Usuario where NombreUsuario = @NombreUsu and Contraseña = @Contraseña";

                    cmd.Parameters.Add(new SqlParameter("NombreUsu", nombreUsu));
                    cmd.Parameters.Add(new SqlParameter("Contraseña", contraseña));

                    var reader4 = cmd.ExecuteReader();

                    if (reader4.HasRows)
                    {
                        ADO_Usuario.TraerUsuario(nombreUsu);
                    }
                    else
                        Console.WriteLine("Nombre de Usuario o Contraseña incorrecta");

                    reader4.Close();
                    connection.Close();

                    return datosUsuario;
                }
            }
        }
    }
}

