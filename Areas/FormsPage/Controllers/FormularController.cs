using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsertToForm.Areas.FormsPage.Controllers
{
    public class FormularController : Controller
    {
        // GET: FormsPage/Formular
        public ActionResult Index()
        {
            return View("~/Areas/FormsPage/Views/Formular/Index.cshtml");
        }
    }
}