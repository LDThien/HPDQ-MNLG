using DA_MNLG.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_MNLG.Controllers
{
    public class ChemicalparametersController : Controller
    {
        TS_NMLGANG_DBEntities1 db_context = new TS_NMLGANG_DBEntities1();
        // GET: Chemicalparameters
        public ActionResult Index(int? page)
        {
            var res = (from a in db_context.NMLGANGTABLE_THONGSOHOAHOCME
                       select new ChemicalparametersValidation()
                       {
                           IDHH = a.IDHH,
                           TPHH_C = (float)a.TPHH_C,
                           TPHH_Si = (float)a.TPHH_Si,
                           TPHH_Mn = (float)a.TPHH_Mn,
                           TPHH_S = (float)a.TPHH_S,
                           TPHH_P = (float)a.TPHH_P,
                           TPHH_Ti = (float)a.TPHH_Ti,
                           TPHH_SiO2 = (float)a.TPHH_SiO2,
                           TPHH_Al2O3 = (float)a.TPHH_Al2O3,
                           TPHH_CaO = (float)a.TPHH_CaO,
                           TPHH_MgO = (float)a.TPHH_MgO,
                           TPHH_TiO2 = (float)a.TPHH_TiO2,
                           TPHH_Ri = (float)a.TPHH_Ri

                       }).ToList();
            if (page == null) page = 1;
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(res.ToList().ToPagedList(pageNumber, pageSize));
        }
    }
}