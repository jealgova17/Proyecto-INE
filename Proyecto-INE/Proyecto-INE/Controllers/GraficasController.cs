using Highsoft.Web.Mvc.Charts;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using Proyecto_INE.Models;
using System.Collections;
using System.Linq;

using System.Data.Entity;
using System.Data;

namespace Proyecto_INE.Controllers
{
    public class GraficasController : Controller
    {

        INEDbContext dbCtx = new INEDbContext();

        
        public ActionResult grafica1()
        {
            int j = 0;

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



            //Cargar DropDownList de los munipios
            var querymunicipios = (from m in dbCtx.Municipios
                                   join c in dbCtx.Candidatos on m.Id equals c.MunicipioId
                                   join v in dbCtx.Votos on c.Id equals v.CandidatoId
                                   where v.votos != 0                             
                                                                 
                                   orderby m.Nombre
                                   select new
                                   {
                                   Id = m.Id,
                                   Nombre = m.Nombre

                                   }).ToList();

            foreach (var item in querymunicipios)
            {
                j = item.Id;
            }

            IEnumerable<SelectListItem> municipio = querymunicipios.GroupBy(x => x.Nombre)
                                                  
                .Select(x => new SelectListItem
                {
                    Text = x.First().Nombre,
                    Value = j.ToString()
                }).ToList();


            TempData["municipio"] = municipio;








            List<PieSeriesData> ConsultaPartidosPoliticos = new List<PieSeriesData>();
            List<PieSeriesData> ConsultaPresidentes = new List<PieSeriesData>();
            List<PieSeriesData> ConsultaGobernadores = new List<PieSeriesData>();






            foreach (var item in query1)
            {
                ConsultaPartidosPoliticos.Add(new PieSeriesData { Name = item.Nombre.ToString()  , Y = Convert.ToInt32(item.Votos)});
            }

            foreach (var item in query2)
            {
                ConsultaPresidentes.Add(new PieSeriesData { Name = item.Candidato.ToString(), Y = Convert.ToInt32(item.Votos) });
            }

            foreach (var item in query2)
            {
                ConsultaGobernadores.Add(new PieSeriesData { Name = item.Candidato.ToString(), Y = Convert.ToInt32(item.Votos) });
            }






            ViewData["ConsultaPartidosPoliticos"] = ConsultaPartidosPoliticos;
            ViewData["ConsultaPresidentes"] = ConsultaPresidentes;
            ViewData["ConsultaGobernadores"] = ConsultaGobernadores;



            return View();
        }

        //public ActionResult Grafica_TodosCandidatos()

        //{

        //    List<PieSeriesData> pieData = new List<PieSeriesData>();

        //    pieData.Add(new PieSeriesData { Name = "FireFox", Y = 45.0 });
        //    pieData.Add(new PieSeriesData { Name = "IE", Y = 26.8 });
        //    pieData.Add(new PieSeriesData { Name = "Chrome", Y = 12.8, Sliced = true, Selected = true });
        //    pieData.Add(new PieSeriesData { Name = "Safari", Y = 8.5 });
        //    pieData.Add(new PieSeriesData { Name = "Opera", Y = 6.2 });
        //    pieData.Add(new PieSeriesData { Name = "Others", Y = 0.7 });

        //    ViewData["pieData"] = pieData;

        //    return View();
        //}


        //    public ActionResult Grafica_TodosCandidatos()
        //{
        //    //List<int> totalVotos = new List<int>();

        //    //var query = (from c in dbCtx.Candidatos
        //    //             join v in dbCtx.Votos on c.Id equals v.CandidatoId
        //    //             group c by c.NombreCandidato into ca
        //    //             select new
        //    //             {
        //    //                 Candidato = ca.Key,
        //    //                 Votos = ca.Count()
        //    //             }).ToList();


        //    List<PieSeriesData> pieData = new List<PieSeriesData>();

        //    pieData.Add(new PieSeriesData { Name = "FireFox", Y = 45.0 });
        //    pieData.Add(new PieSeriesData { Name = "IE", Y = 26.8 });
        //    pieData.Add(new PieSeriesData { Name = "Chrome", Y = 12.8, Sliced = true, Selected = true });
        //    pieData.Add(new PieSeriesData { Name = "Safari", Y = 8.5 });
        //    pieData.Add(new PieSeriesData { Name = "Opera", Y = 6.2 });
        //    pieData.Add(new PieSeriesData { Name = "Others", Y = 0.7 });

        //    ViewData["pieData"] = pieData;

        //    return View();



        //}




    }
    }
