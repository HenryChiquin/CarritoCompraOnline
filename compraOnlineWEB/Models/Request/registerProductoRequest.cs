using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace compraOnlineWEB.Models.Request
{
    public class registerProductoRequest
    {
        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required]
        [DisplayName("Precio")]
        public decimal Precio { get; set; }
        [Required]
        [DisplayName("Existencia")]
        public int Existencia { get; set; }
        public int Id_SubCategoria { get; set; }
        public string Descripcion { get; set; }
        public byte[] ImgProducto { get; set; }
        public HttpPostedFileBase archivo { get; set; }
        
    }
}