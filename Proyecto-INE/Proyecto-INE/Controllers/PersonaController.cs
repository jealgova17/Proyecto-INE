using Proyecto_INE.Models;
using Proyecto_INE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_INE.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(PersonaViewModel model)
        {

            Persona p = null;


            using (INEDbContext dbCtx = new INEDbContext())
            {
                p = dbCtx.Personas.Where(x => x.Curp.Equals(model.Curp) && x.CIC.Equals(model.CIC)).SingleOrDefault();

                if (ModelState.IsValid)
                {
                    if (p != null)
                    {
                        Session["curp"] = p.Curp.ToString();
                        return RedirectToAction("Usuario", "Persona");

                    }
                    else
                    {

                        Response.Write("<script language='javascript' type='text/javascript'>alert('El CURP o CIC son incorrectos ');</script>");

                        return View(p);
                    }

                }
            }

            return View(p);
        }
        public ActionResult Usuario()
        {
            Persona p = null;

            if (Session["curp"] != null)
            {
                //var path = Server.MapPath("~") + @"Images";
                var fileName = Session["curp"].ToString();
                //var fileFull = path + "\\" + fileName + ".jpg";

                ViewBag.foto = fileName + ".jpg";

                using (INEDbContext dbCtx = new INEDbContext())
                {
                    p = dbCtx.Personas.Where(x => x.Curp == fileName).SingleOrDefault();


                }

            }

            return View(p);
        }


        public ActionResult Normas()
        {

            return View();
        }

        public ActionResult Candidato()
        {

            return View();
        }

        public ActionResult Apodaca()
        {

            return View();
        }

        public ActionResult Monterrey()
        {

            return View();
        }

        public ActionResult Pesqueria()
        {

            return View();
        }

        public ActionResult Sannico()
        {

            return View();
        }

        public ActionResult Escobedo()
        {

            return View();
        }



    }
}