
using ADO_Classes;


class Program
{

    static void Main(string[] args)
    {

        string nombreUsuario = "tcasazzas";
        string contraseña = "NewPass";
        int idUsuario = 1;

        ADO_Usuario.TraerUsuario(nombreUsuario);
        ADO_Producto.DevolverProducto(idUsuario);
        ADO_ProductoVendidoPorUsuario.DevolverProductoVendidoPorUser(idUsuario);
        ADO_Venta.TraerVentaPorUsuario(idUsuario);
        ADO_InicioSesion.InicioSesion(nombreUsuario, contraseña);





    }
}