using Google.Apis.Sheets.v4;
using TransitorImagens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransitorImagens.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> lista = GoogleSheet.Sheets();
            double tempoTransicao = GoogleSheet.BuscaTempo();

            ViewBag.ListaImagens = lista;
            ViewBag.TempoTransicao = tempoTransicao;

            return View();
        }
    }
}