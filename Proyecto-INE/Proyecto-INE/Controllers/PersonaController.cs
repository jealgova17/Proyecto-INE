using Highsoft.Web.Mvc.Charts;
using Newtonsoft.Json;
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

                var fileName = Session["curp"].ToString();
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
            return View();
        }

        public ActionResult BoletaPresidente()
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
                                  materno = p.ApellidoMaternoCandidato,
                                  partido = p.PartidoPoliticoId,
                                  id = p.Id
                              }).ToList();


                List<CandidatoViewModel> candidatosPresidentes = new List<CandidatoViewModel>();
                foreach (var i in query1)
                {
                    CandidatoViewModel vm = new CandidatoViewModel()
                    {
                        NombreCandidato = i.nombre,
                        ApellidoPaternoCandidato = i.paterno,
                        ApellidoMaternoCandidato = i.materno,
                        PartidoPoliticoId = i.partido,
                        Id = i.id

                    };
                    candidatosPresidentes.Add(vm);
                }

                Session["presi"] = candidatosPresidentes;

                return View();
            }

        }

        public ActionResult BoletaEstado(CandidatoViewModel vm)
        {
            Voto vv = new Voto();
            using (INEDbContext dbCtx = new INEDbContext())
            {


                vv.CandidatoId = vm.Id;
                vv.votos = 1;
                dbCtx.Votos.Add(vv);
                dbCtx.SaveChanges();




                int m = Convert.ToInt32(Session["municipio"]);
                var query2 = (from p in dbCtx.Candidatos
                              join pp in dbCtx.Puestos on p.PuestoId equals pp.Id
                              join ppp in dbCtx.Municipios on p.MunicipioId equals ppp.Id
                              where p.EstadoId == 1 && p.PuestoId == 2
                              select new
                              {
                                  nombre = p.NombreCandidato,
                                  paterno = p.ApellidoPaternoCandidato,
                                  materno = p.ApellidoMaternoCandidato,
                                  partido = p.PartidoPoliticoId,
                                  id = p.Id
                              }).ToList();

                List<CandidatoViewModel> candidatosGober = new List<CandidatoViewModel>();
                foreach (var i in query2)
                {
                    CandidatoViewModel vmm = new CandidatoViewModel()
                    {
                        NombreCandidato = i.nombre,
                        ApellidoPaternoCandidato = i.paterno,
                        ApellidoMaternoCandidato = i.materno,
                        PartidoPoliticoId = i.partido,
                        Id = i.id
                    };
                    candidatosGober.Add(vmm);
                }

                Session["gober"] = candidatosGober;
            }
            return View();
        }

        public ActionResult BoletaMunicipio(CandidatoViewModel vm)
        {
            Voto vv = new Voto();
            using (INEDbContext dbCtx = new INEDbContext())
            {


                vv.CandidatoId = vm.Id;
                vv.votos = 1;
                dbCtx.Votos.Add(vv);
                dbCtx.SaveChanges();

                int m = Convert.ToInt32(Session["municipio"]);


                var query3 = (from p in dbCtx.Candidatos
                              join pp in dbCtx.Puestos on p.PuestoId equals pp.Id
                              join ppp in dbCtx.Municipios on p.MunicipioId equals ppp.Id
                              where p.MunicipioId == m && p.PuestoId == 3
                              select new
                              {
                                  nombre = p.NombreCandidato,
                                  paterno = p.ApellidoPaternoCandidato,
                                  materno = p.ApellidoMaternoCandidato,
                                  partido = p.PartidoPoliticoId,
                                  id = p.Id
                              }).ToList();


                List<CandidatoViewModel> candidatosMunicipales = new List<CandidatoViewModel>();
                foreach (var i in query3)
                {
                    CandidatoViewModel vmm = new CandidatoViewModel()
                    {
                        NombreCandidato = i.nombre,
                        ApellidoPaternoCandidato = i.paterno,
                        ApellidoMaternoCandidato = i.materno,
                        PartidoPoliticoId = i.partido,
                        Id = i.id
                    };

                    candidatosMunicipales.Add(vmm);
                }


                Session["muni"] = candidatosMunicipales;
                return View();
            }
        }

        public ActionResult Graficas(CandidatoViewModel vm)
        {
            Voto vv = new Voto();
            using (INEDbContext dbCtx = new INEDbContext())
            {


                vv.CandidatoId = vm.Id;
                vv.votos = 1;
                dbCtx.Votos.Add(vv);
                dbCtx.SaveChanges();




                int j = 0;

                //
                var query1 = (from p in dbCtx.PartidoPoliticos
                              join c in dbCtx.Candidatos on p.Id equals c.PartidoPoliticoId
                              join v in dbCtx.Votos on c.Id equals v.CandidatoId
                              group p by p.Nombre into pa
                              select new
                              {
                                  Nombre = pa.Key,
                                  Votos = pa.Count()
                              }).ToList();


                //Presidentes
                var query2 = (from c in dbCtx.Candidatos
                              join v in dbCtx.Votos
                              on c.Id equals v.CandidatoId
                              where c.PuestoId == 1

                              group c by c.NombreCandidato into ca
                              select new
                              {
                                  Candidato = ca.Key,
                                  Votos = ca.Count()
                              }).ToList();

                //Gobernadores
                var query3 = (from c in dbCtx.Candidatos
                              join v in dbCtx.Votos
                              on c.Id equals v.CandidatoId
                              where c.PuestoId == 2

                              group c by c.NombreCandidato into ca
                              select new
                              {
                                  Candidato = ca.Key,
                                  Votos = ca.Count()
                              }).ToList();



                int variable = int.Parse(Session["municipio"].ToString());

                var query4 = (from c in dbCtx.Candidatos
                              join v in dbCtx.Votos
                              on c.Id equals v.CandidatoId
                              where c.PuestoId == 3
                              && c.MunicipioId == variable

                              group c by c.NombreCandidato into ca
                              select new
                              {
                                  Candidato = ca.Key,
                                  Votos = ca.Count()
                              }).ToList();



                List<PieSeriesData> ConsultaPartidosPoliticos = new List<PieSeriesData>();
                List<PieSeriesData> ConsultaPresidentes = new List<PieSeriesData>();
                List<PieSeriesData> ConsultaGobernadores = new List<PieSeriesData>();
                List<PieSeriesData> ConsultaAcaldes = new List<PieSeriesData>();






                foreach (var item in query1)
                {
                    ConsultaPartidosPoliticos.Add(new PieSeriesData { Name = item.Nombre.ToString(), Y = Convert.ToInt32(item.Votos) });
                }

                foreach (var item in query2)
                {
                    ConsultaPresidentes.Add(new PieSeriesData { Name = item.Candidato.ToString(), Y = Convert.ToInt32(item.Votos) });
                }

                foreach (var item in query3)
                {
                    ConsultaGobernadores.Add(new PieSeriesData { Name = item.Candidato.ToString(), Y = Convert.ToInt32(item.Votos) });
                }

                foreach (var item in query4)
                {
                    ConsultaAcaldes.Add(new PieSeriesData { Name = item.Candidato.ToString(), Y = Convert.ToInt32(item.Votos) });
                }






                ViewData["ConsultaPartidosPoliticos"] = ConsultaPartidosPoliticos;
                ViewData["ConsultaPresidentes"] = ConsultaPresidentes;
                ViewData["ConsultaGobernadores"] = ConsultaGobernadores;
                ViewData["ConsultaAcaldes"] = ConsultaAcaldes;


                return View();

            }
        }

        public ActionResult ConsultaPartidosPoliticos(CandidatoViewModel vm)
        {

            Voto vv = new Voto();
            using (INEDbContext dbCtx = new INEDbContext())
            {


                vv.CandidatoId = vm.Id;
                vv.votos = 1;
                dbCtx.Votos.Add(vv);
                dbCtx.SaveChanges();

                //PartidosPoliticos
                var query1 = (from p in dbCtx.PartidoPoliticos
                              join c in dbCtx.Candidatos on p.Id equals c.PartidoPoliticoId
                              join v in dbCtx.Votos on c.Id equals v.CandidatoId
                              group p by p.Nombre into pa
                              select new
                              {
                                  Nombre = pa.Key,
                                  Votos = pa.Count()
                              }).ToList();


                List<PieSeriesData> ConsultaPartidosPoliticos = new List<PieSeriesData>();

                foreach (var item in query1)
                {
                    ConsultaPartidosPoliticos.Add(new PieSeriesData { Name = item.Nombre.ToString(), Y = Convert.ToInt32(item.Votos) });
                }
                ViewData["ConsultaPartidosPoliticos"] = ConsultaPartidosPoliticos;

                return View();
            }
        }

        public ActionResult ConsultaPresidentes()
        {
            using (INEDbContext dbCtx = new INEDbContext())
            {
                //Presidentes
                var query2 = (from c in dbCtx.Candidatos
                              join v in dbCtx.Votos
                              on c.Id equals v.CandidatoId
                              where c.PuestoId == 1

                              group c by c.NombreCandidato into ca
                              select new
                              {
                                  Candidato = ca.Key,
                                  Votos = ca.Count()
                              }).ToList();

                List<PieSeriesData> ConsultaPresidentes = new List<PieSeriesData>();

                foreach (var item in query2)
                {
                    ConsultaPresidentes.Add(new PieSeriesData { Name = item.Candidato.ToString(), Y = Convert.ToInt32(item.Votos) });
                }

                ViewData["ConsultaPresidentes"] = ConsultaPresidentes;

                return View();
            }
        }

        public ActionResult ConsultaGobernadores()
        {
            using (INEDbContext dbCtx = new INEDbContext())
            {
                //Gobernadores
                var query3 = (from c in dbCtx.Candidatos
                              join v in dbCtx.Votos
                              on c.Id equals v.CandidatoId
                              where c.PuestoId == 2

                              group c by c.NombreCandidato into ca
                              select new
                              {
                                  Candidato = ca.Key,
                                  Votos = ca.Count()
                              }).ToList();



                List<PieSeriesData> ConsultaGobernadores = new List<PieSeriesData>();

                foreach (var item in query3)
                {
                    ConsultaGobernadores.Add(new PieSeriesData { Name = item.Candidato.ToString(), Y = Convert.ToInt32(item.Votos) });
                }

                ViewData["ConsultaGobernadores"] = ConsultaGobernadores;

                return View();
            }
        }


        public ActionResult ConsultaAlcaldes()
        {
            using (INEDbContext dbCtx = new INEDbContext())
            {
                int variable = int.Parse(Session["municipio"].ToString());

                var query4 = (from c in dbCtx.Candidatos
                              join v in dbCtx.Votos
                              on c.Id equals v.CandidatoId
                              where c.PuestoId == 3
                              && c.MunicipioId == variable

                              group c by c.NombreCandidato into ca
                              select new
                              {
                                  Candidato = ca.Key,
                                  Votos = ca.Count()
                              }).ToList();


                List<PieSeriesData> ConsultaAcaldes = new List<PieSeriesData>();

                foreach (var item in query4)
                {
                    ConsultaAcaldes.Add(new PieSeriesData { Name = item.Candidato.ToString(), Y = Convert.ToInt32(item.Votos) });
                }

                ViewData["ConsultaAcaldes"] = ConsultaAcaldes;

                return View();
            }
        }


        public ActionResult contacto()
        {

            return View();
        }


    }

}
