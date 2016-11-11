using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMB_MVC.Controllers
{
  public class LoginController : Controller
  {
    // GET: Login
    public ActionResult Get()
    {
      return HttpNotFound("No existe el recurso por ahora");
    }
  }
}