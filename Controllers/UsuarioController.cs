

namespace Controllers
{

    public class UsuarioController
    {

        public class Usuario

        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string NombreUsuario { get; set; }
            public string Contraseña { get; set; }
            public string Mail { get; set; }
        }



        //public List<Usuario> Get()
        //{
        //    return ADO_Usuario.DevolverUsuarios();
        //}
    }
}
