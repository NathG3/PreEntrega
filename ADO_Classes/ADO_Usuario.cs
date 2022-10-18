using ConsoleApp.Modelos;
using System.Data;
using System.Data.SqlClient;


namespace ADO_Classes
{
    public class ADO_Usuario
    {

        public static Usuario TraerUsuario(string nombreUsuario)
        {
            var usuario = new Usuario();


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
                    cmd.CommandText = "SELECT * FROM Usuario where NombreUsuario = @IDUsu";

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IDUsu";
                    parametro.SqlDbType = SqlDbType.VarChar;
                    parametro.Value = nombreUsuario;

                    cmd.Parameters.Add(parametro);

                    var reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        

                        usuario.Id = Convert.ToInt32(reader.GetValue(0));
                        usuario.Nombre = reader.GetValue(1).ToString();
                        usuario.Apellido = reader.GetValue(2).ToString();
                        usuario.NombreUsuario = reader.GetValue(3).ToString();
                        usuario.Contraseña = reader.GetValue(4).ToString();
                        usuario.Mail = reader.GetValue(5).ToString();

                        
                    }
                    reader.Close();
                    connection.Close();



                    return usuario;


                }
            }
        }
    }
}

