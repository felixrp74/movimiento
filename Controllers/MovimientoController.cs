using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_1.Models;
using Prueba_1.Models.ViewModels;

namespace Prueba_1.Controllers
{
    public class MovimientoController : Controller
    {
        // GET: Movimiento
        [HttpGet]
        public ActionResult Anadir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Anadir(MovimientoViewModel model)
        {
            try
            {
                using ( Prueba3Entities db = new Prueba3Entities() )
                {
                    Responsable oResponsable = new Responsable();
                    oResponsable.Nombre = model.Responsable;
                    db.Responsable.Add(oResponsable);
                    db.SaveChanges();

                    foreach(var mE in model.Equipos)
                    {
                        Dispositivo oDispositivo = new Dispositivo();
                        oDispositivo.Descripcion = mE.Descripcion;
                        oDispositivo.Marca = mE.Marca;
                        db.Dispositivo.Add(oDispositivo);

                        db.SaveChanges();

                        foreach (var mM in model.Movimientos)
                        {
                            Movimiento oMovimiento = new Movimiento();
                            oMovimiento.Fecha = DateTime.Now;
                            oMovimiento.Origen = mM.Origen;
                            oMovimiento.Destino = mM.Destino;
                            oMovimiento.Clave_R1 = oResponsable.Clave_R;
                            oMovimiento.Clave_D1 = oDispositivo.Clave_D;

                            db.Movimiento.Add(oMovimiento);
                        }
                        db.SaveChanges();

                    }
                    db.SaveChanges();
                    
                }

                ViewBag.Message = "Registro insertado";

                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }


        }
    }
}