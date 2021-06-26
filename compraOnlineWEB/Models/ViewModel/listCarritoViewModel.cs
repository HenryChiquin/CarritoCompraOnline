using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compraOnlineWEB.Models.ViewModel
{
    public class listCarritoViewModel
    {
        public int Id_Producto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public byte[] ImgProducto { get; set; }
    }
}