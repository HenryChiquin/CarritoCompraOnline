using compraOnlineWEB.Models.Request;
using compraOnlineWEB.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using compraOnlineWEB.Models;
using System.IO;

namespace compraOnlineWEB.Controllers
{
    public class registerProductoController : Controller
    {
        // GET: registerProducto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult nuevoProducto()
        {
            registerProductoRequest model = new registerProductoRequest();

            List<listCategoriaViewModel> lst = new List<listCategoriaViewModel>();

            using (carritoCompraDBEntities db = new carritoCompraDBEntities())
            {
                lst = (from d in db.CATEGORIA
                       select new listCategoriaViewModel
                       {
                           Id_Categoria = d.Id_Categoria,
                           Nombre = d.Nombre
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.Id_Categoria.ToString(),
                    Text = d.Nombre.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = items;
            return View(model);
        }
        [HttpPost]
        public ActionResult nuevoProducto(registerProductoRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.archivo != null && model.archivo.ContentLength > 0)
                    {
                        byte[] imagenData = null;
                        using (var imagen = new BinaryReader(model.archivo.InputStream))
                        {
                            imagenData = imagen.ReadBytes(model.archivo.ContentLength);

                        }
                        model.ImgProducto = imagenData;
                    }
                    using (carritoCompraDBEntities db = new carritoCompraDBEntities())
                    {
                        var oProducto = new PRODUCTO();
                        oProducto.Nombre = model.Nombre;
                        oProducto.Precio = model.Precio;
                        oProducto.Existencia = model.Existencia;
                        oProducto.Id_SubCategoria = 4;
                        oProducto.ImgProducto = model.ImgProducto;
                        oProducto.Fecha = DateTime.Now;
                        oProducto.Descripcion = model.Descripcion;

                        db.PRODUCTO.Add(oProducto);
                        db.SaveChanges();
                    }
                    return Redirect("~/registerProducto/nuevoProducto");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }
        #region HELPERS
        public JsonResult subCategoria(int IdCategoria)
        {
            List<ElementJsonIntKey> lista = new List<ElementJsonIntKey>();
            using (carritoCompraDBEntities db = new carritoCompraDBEntities())
            {
                lista = (from d in db.SUB_CATEGORIA
                         where d.Id_Categoria == IdCategoria
                         select new ElementJsonIntKey
                         {
                             Value = d.Id_SubCategoria,
                             Text = d.Nombre
                         }).ToList();
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public class ElementJsonIntKey
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }
        #endregion
    }
}