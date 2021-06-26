using compraOnlineWEB.Models;
using compraOnlineWEB.Models.ViewModel;
using compraOnlineWEB.Models.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace compraOnlineWEB.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductosOnline()
        {
            try
            {

                List<listCategoriaViewModel> lista;
                using (carritoCompraDBEntities db = new carritoCompraDBEntities())
                {
                    lista = (from d in db.CATEGORIA
                             select new listCategoriaViewModel
                             {
                                 Id_Categoria = d.Id_Categoria,
                                 Nombre = d.Nombre
                             }).ToList();
                }
                ViewBag.ListCategoria = lista;


                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult catalogoSubcategoria(int Id)
        {
            List<listSubCategoriaViewModel> listasC;

            using (carritoCompraDBEntities db = new carritoCompraDBEntities())
            {
                listasC = (from d in db.SUB_CATEGORIA
                           where d.Id_Categoria == Id
                           select new listSubCategoriaViewModel
                           {
                               Id_subCategoria = d.Id_SubCategoria,
                               Nombre = d.Nombre
                           }).ToList();
            }
         //   ViewBag.catSubCategoria = listasC;
            return View(listasC);
        }
        
        [HttpGet]
        public ActionResult catalogoProductos(int Id)
        {
            List<listProductoViewModel> lista;
            using (carritoCompraDBEntities db = new carritoCompraDBEntities())
            {
                lista = (from d in db.PRODUCTO
                         where d.Id_SubCategoria==Id
                         select new listProductoViewModel
                         {   
                             Id_Producto=d.Id_Producto,
                             SubCategoria=d.SUB_CATEGORIA.Nombre,
                             Nombre=d.Nombre,
                             Precio=d.Precio,
                             Descripcion=d.Descripcion,
                             ImgProducto=d.ImgProducto 
                         }).ToList();
            }
            
            return View(lista);
        }
   

        public void Carrito(int Id)
        {
            Reply oR = new Reply();
            oR.result = 0;
            if (!ModelState.IsValid)
            {
                oR.message = "Modelo no encontrado";
                
            }
            try
            {
               
                using (carritoCompraDBEntities db = new carritoCompraDBEntities())
                {
                    var oCarrito = new CARRITO();
                    oCarrito.Id_Producto = Id;
                    oCarrito.Cantidad = 1;

                    db.CARRITO.Add(oCarrito);
                    db.SaveChanges();

                    oR.result = 1;
                }
                
            }
            catch (Exception ex)
            {
                oR.result = 0;
                oR.message = "intenta de nuevo mas tarde";
            }
            
        }
        public ActionResult CarritoMenu()
        {
            List<listCarritoViewModel> lst = new List<listCarritoViewModel>();

            using (carritoCompraDBEntities db = new carritoCompraDBEntities())
            {
                lst = (from d in db.CARRITO
                       select new listCarritoViewModel
                       {
                           ImgProducto = d.PRODUCTO.ImgProducto,
                           NombreProducto = d.PRODUCTO.Nombre,
                           PrecioProducto=d.PRODUCTO.Precio
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.ImgProducto.ToString(),
                    Text = d.NombreProducto.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = items;
            return View();
        }

    }
}
