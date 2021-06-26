//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace compraOnlineWEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            this.CARRITO = new HashSet<CARRITO>();
            this.DETALLE = new HashSet<DETALLE>();
        }
    
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public int Id_SubCategoria { get; set; }
        public byte[] ImgProducto { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITO> CARRITO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE> DETALLE { get; set; }
        public virtual SUB_CATEGORIA SUB_CATEGORIA { get; set; }
    }
}
