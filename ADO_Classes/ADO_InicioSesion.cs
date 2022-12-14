using ConsoleApp.Modelos;
using System.Data;
using System.Data.SqlClient;


namespace ADO_Classes
{
    public class ADO_InicioSesion
    {
        public static Usuario InicioSesion(string nombreUsuario, string contraseña)
        {
            var datosUsuario = new Usuario();

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

                    cmd.Parameters.Add(new SqlParameter("NombreUsu", nombreUsuario));
                    cmd.Parameters.Add(new SqlParameter("Contraseña", contraseña));

                    var reader4 = cmd.ExecuteReader();

                    if (reader4.HasRows)
                    {

                        datosUsuario = ADO_Usuario.TraerUsuario(nombreUsuario);

                    }
                    else
                    {
                        datosUsuario = new Usuario();
                    }

                    reader4.Close();
                    connection.Close();


                    return datosUsuario;
                }
            }
        }
    }
}

