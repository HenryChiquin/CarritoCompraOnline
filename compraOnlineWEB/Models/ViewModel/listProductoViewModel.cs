using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace compraOnlineWEB.Models.ViewModel
{
    public class listProductoViewModel
    {    
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public string Descripcion { get; set; }
        public int Id_SubCategoria { get; set; }
        public string SubCategoria { get; set; }
        public byte[] ImgProducto { get; set; }
        public HttpPostedFileBase archivo { get; set; }
    }
}