using DA_MNLG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace DA_MNLG.Controllers
{
    public class ShiftController : Controller
    {
        TS_NMLGANG_DBEntities1 db_context = new TS_NMLGANG_DBEntities1();
        // GET: Shift
        public ActionResult Index(int? page)
        {
            var res = (from a in db_context.CA_TABLE
                       select new ShiftValidation()
                       {
                           IDCa = a.IDCa,
                           TenCa = a.TenCa
                       }
                       ).ToList();
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = ((int)(page ?? 1));
            return View(res.ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return PartialView();
        }
        //[HttpPost]
        //public ActionResult Create(ShiftValidation _DO)
        //{
        //    return PartialView();
        //}
    }
}