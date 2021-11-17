using DA_MNLG.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_MNLG.Controllers
{
    public class PhysicalparametersController : Controller
    {
        TS_NMLGANG_DBEntities1 db_context = new TS_NMLGANG_DBEntities1();
        // GET: Physicalparameters
        public ActionResult Index(int? page)
        {
            var res = from a in db_context.NMLGANGTABLE_THONGSOVATLYME
                      select new PhysicalparametersValidation
                      {
                          IDVL = a.IDVL,
                          thoiGianRaGang = (int)a.thoiGianRaGang,
                          gianCach = (int)a.gianCach,
                          thoiGianRaXi = (int)a.thoiGianRaXi,
                          tiLeTGGangXi = (float)a.tiLeTGGangXi,
                          doSauLoGang = (float)a.doSauLoGang,
                          luongBunBit = (float)a.luongBunBit,
                          sanLuong = (float)a.sanLuong,
                          nhietDoGang = (float)a.nhietDoGang,
                          khoiLuong = (float)a.khoiLuong,
                          loaiGang = (int)a.loaiGang
                      };
            if (page == null) page = 1;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(res.ToList().ToPagedList(pageNumber, pageSize));
        }
    }
}