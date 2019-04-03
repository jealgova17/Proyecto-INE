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
        public ActionResult Candidato()
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

                    Session["municipio"] = p.MunicipioId;
                    
                }
            }
            return View(p);
        }


        public ActionResult Normas()
        {
            RedirectToAction("CC", "Persona");
            return View();
        }

        public ActionResult CC()
        {
         
          
            int m = Convert.ToInt32(Session["municipio"]);
         
            using (INEDbContext dbCtx = new INEDbContext())
            {
                var query1 = (from p in dbCtx.Candidatos
                             join pp in dbCtx.Puestos on p.PuestoId equals pp.Id
                             join ppp in dbCtx.Municipios on p.MunicipioId equals ppp.Id
                             where p.PuestoId == 1
                             select new
                             {
                                 nombre = p.NombreCandidato,
                                 paterno = p.ApellidoPaternoCandidato,
                                 materno = p.ApellidoMaternoCandidato
                             }).ToList();

                var query2 = (from p in dbCtx.Candidatos
                              join pp in dbCtx.Puestos on p.PuestoId equals pp.Id
                              join ppp in dbCtx.Municipios on p.MunicipioId equals ppp.Id
                              where p.EstadoId == 1 && p.PuestoId == 2
                              select new
                              {
                                  nombre = p.NombreCandidato,
                                  paterno = p.ApellidoPaternoCandidato,
                                  materno = p.ApellidoMaternoCandidato
                              }).ToList();

                var query3 = (from p in dbCtx.Candidatos
                              join pp in dbCtx.Puestos on p.PuestoId equals pp.Id
                              join ppp in dbCtx.Municipios on p.MunicipioId equals ppp.Id
                              where p.MunicipioId == m && p.PuestoId == 3
                              select new
                              {
                                  nombre = p.NombreCandidato,
                                  paterno = p.ApellidoPaternoCandidato,
                                  materno = p.ApellidoMaternoCandidato
                              }).ToList();


                List<CandidatoViewModel> candidatosPresidentes = new List<CandidatoViewModel>();

                foreach (var i in query1)
                {
                    CandidatoViewModel vm = new CandidatoViewModel()
                    {
                        NombreCandidato = i.nombre,
                        ApellidoPaternoCandidato = i.paterno,
                        ApellidoMaternoCandidato = i.materno
                    };

                    candidatosPresidentes.Add(vm);
                }


                List<CandidatoViewModel> candidatosGober = new List<CandidatoViewModel>();

                foreach (var i in query2)
                {
                    CandidatoViewModel vm = new CandidatoViewModel()
                    {
                        NombreCandidato = i.nombre,
                        ApellidoPaternoCandidato = i.paterno,
                        ApellidoMaternoCandidato = i.materno
                    };

                    candidatosGober.Add(vm);
                }

                List<CandidatoViewModel> candidatosMunicipales = new List<CandidatoViewModel>();

                foreach (var i in query3)
                {
                    CandidatoViewModel vm = new CandidatoViewModel()
                    {
                        NombreCandidato = i.nombre,
                        ApellidoPaternoCandidato = i.paterno,
                        ApellidoMaternoCandidato = i.materno
                    };

                    candidatosMunicipales.Add(vm);
                }

                Session["presi"] = candidatosPresidentes;
                Session["gober"] = candidatosGober;
                Session["muni"] = candidatosMunicipales;

                return View();
            }



        }

  

        

    }
}