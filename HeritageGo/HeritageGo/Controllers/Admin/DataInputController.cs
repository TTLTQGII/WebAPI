using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeritageGo.Controllers.Admin
{
    
    public class DataInputController : Controller
    {
        // GET: DataInput
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertHeritagerInfo()
        {
            return View();
        }
    }
}