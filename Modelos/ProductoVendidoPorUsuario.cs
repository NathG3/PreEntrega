

namespace ConsoleApp.Modelos
{
    public class ProductoVendidoPorUsuario
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public string Descripciones { get; set; }
        public double PrecioVenta { get; set; }
        public double IdUsuario { get; set; }

    }
}
