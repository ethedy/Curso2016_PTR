using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace OMB_MVC.Controllers
{
  public class HomeController : Controller
  {
    // GET: Home
    public ActionResult Inicio()
    {
      return View();
    }
  }
}