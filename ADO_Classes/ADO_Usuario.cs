using System.Data;
using System.Data.SqlClient;
using static Controllers.UsuarioController;

namespace ADO_Classes
{
    public class ADO_Usuario
    {

        public static List<Usuario> TraerUsuario(string nombreUsuario)
        {
            var datosUsuario = new List<Usuario>();


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
                        var usuario = new Usuario();

                        usuario.Id = Convert.ToInt32(reader.GetValue(0));
                        usuario.Nombre = reader.GetValue(1).ToString();
                        usuario.Apellido = reader.GetValue(2).ToString();
                        usuario.NombreUsuario = reader.GetValue(3).ToString();
                        usuario.Contraseña = reader.GetValue(4).ToString();
                        usuario.Mail = reader.GetValue(5).ToString();

                        datosUsuario.Add(usuario);

                        Console.WriteLine();
                        Console.WriteLine("---- Informacion del Usuario: {0}", nombreUsuario);
                        foreach (var datUser in datosUsuario)
                        {
                            Console.WriteLine("Id = " + usuario.Id);
                            Console.WriteLine("Nombre = " + usuario.Nombre);
                            Console.WriteLine("Apellido = " + usuario.Apellido);
                            Console.WriteLine("NombreUsuario = " + usuario.NombreUsuario);
                            Console.WriteLine("Contraseña = " + usuario.Contraseña);
                            Console.WriteLine("Mail = " + usuario.Mail);
                            Console.WriteLine("--------------");

                        }
                    }
                    reader.Close();
                    connection.Close();



                    return datosUsuario;


                }
            }
        }
    }
}

