using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ProductoVendidoPorUsuarioController
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public string Descripciones { get; set; }
        public double PrecioVenta { get; set; }
        public double IdUsuario { get; set; }

    }
}
