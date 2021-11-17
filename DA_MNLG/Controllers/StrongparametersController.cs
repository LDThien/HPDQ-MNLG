using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using DA_MNLG.Models;
using PagedList;

namespace DA_MNLG.Controllers
{
    public class StrongparametersController : Controller
    {
        TS_NMLGANG_DBEntities1 db_context = new TS_NMLGANG_DBEntities1();
        // GET: Strongparameters
        public ActionResult Index(int? page, DateTime? begind, DateTime? endd)
        {
            var res = (from a in db_context.NMLGANGTABLE_THONGSOME
                      where (a.thoiGian >= begind && a.thoiGian <= endd)
                      select new StrongparametersValidation
                      {
                          IDM = a.IDM,
                          thoiGian = (DateTime)a.thoiGian,
                          caID = (int)a.caID,
                          //Tenca = ca.TenCa,
                          meGang = (int)a.meGang,
                          soThung = (int)a.soThung,
                          sanRaGang = (int)a.sanRaGang

                      }).OrderByDescending(x => x.thoiGian).ToList();
            if (page == null) page = 1;
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(res.ToList().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult _ToolSearch(StrongparametersValidation DO)
        {
            return PartialView(DO);
        }

        public IList<StrongparametersValidation> GetStrongparameters(DateTime? begind, DateTime? endd)
        {
            var res = (from a in db_context.NMLGANGTABLE_THONGSOME
                      where (a.thoiGian >= begind && a.thoiGian <= endd)
                      select new StrongparametersValidation
                      {
                          IDM = a.IDM,
                          thoiGian = (DateTime)a.thoiGian,
                          caID = (int)a.caID,
                          //Tenca = ca.TenCa,
                          meGang = (int)a.meGang,
                          soThung = (int)a.soThung,
                          sanRaGang = (int)a.sanRaGang

                      }).OrderByDescending(x => x.thoiGian).ToList(); ;
            return res;
        }
        public ActionResult ExportToExcel(DateTime? begind, DateTime? endd)
        {
            try
            {
              
                    string fileNamemau = AppDomain.CurrentDomain.BaseDirectory + @"App_Data\TSVL.xlsx";
                    string fileNamemaunew = AppDomain.CurrentDomain.BaseDirectory + @"App_Data\TSVL_Temp.xlsx";
                    XLWorkbook Workbook = new XLWorkbook(fileNamemau);
                    IXLWorksheet Worksheet = Workbook.Worksheet("TSVL");

                    IList<StrongparametersValidation> Strongparameters = GetStrongparameters (begind, endd);

                    if (Strongparameters.Count > 0)
                    {
                        int row = 2, rowlast = 2, pd = 0, stt = 0;
                        foreach (var item in Strongparameters)
                        {
                            row++; stt++; pd = 0;
                            if (pd != 0)
                                rowlast = row + pd;
                            else
                                rowlast = row + 1;
                            Worksheet.Cell("A" + row).Value = stt;
                            Worksheet.Cell("A" + row).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            Worksheet.Cell("A" + row).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


                            Worksheet.Cell("B" + row).Value = item.thoiGian.ToString();
                            Worksheet.Cell("B" + row).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            Worksheet.Cell("B" + row).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            Worksheet.Cell("B" + row).Style.DateFormat.Format = "dd/MM/yyyy";

                            Worksheet.Cell("C" + row).Value = item.caID;
                            Worksheet.Cell("C" + row).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            Worksheet.Cell("C" + row).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            Worksheet.Cell("C" + row).Style.Alignment.WrapText = true;

                            Worksheet.Cell("D" + row).Value = item.meGang;
                            Worksheet.Cell("D" + row).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            Worksheet.Cell("D" + row).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            Worksheet.Cell("D" + row).Style.Alignment.WrapText = true;

                            Worksheet.Cell("E" + row).Value = item.soThung;
                            Worksheet.Cell("E" + row).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            Worksheet.Cell("E" + row).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            Worksheet.Cell("E" + row).Style.Alignment.WrapText = true;

                            Worksheet.Cell("F" + row).Value = item.sanRaGang;
                            Worksheet.Cell("F" + row).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            Worksheet.Cell("F" + row).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            Worksheet.Cell("F" + row).Style.Alignment.WrapText = true;

                            if (pd > 1)
                            {
                                //stt
                                Worksheet.Range("A" + row + ":A" + (rowlast - 1)).Merge();
                                Worksheet.Range("B" + row + ":B" + (rowlast - 1)).Merge();
                                Worksheet.Range("C" + row + ":C" + (rowlast - 1)).Merge();
                                Worksheet.Range("D" + row + ":D" + (rowlast - 1)).Merge();
                                Worksheet.Range("E" + row + ":E" + (rowlast - 1)).Merge();
                                Worksheet.Range("F" + row + ":F" + (rowlast - 1)).Merge();
                            }
                            row = rowlast - 1;
                        }
                        Worksheet.Range("A3:F" + (row)).Style.Font.SetFontName("Times New Roman");
                        Worksheet.Range("A3:F" + (row)).Style.Font.SetFontSize(11);
                        Worksheet.Range("A3:F" + (row)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Worksheet.Range("A3:F" + (row)).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        Workbook.SaveAs(fileNamemaunew);
                        byte[] fileBytes = System.IO.File.ReadAllBytes(fileNamemaunew);
                        string fileName = "TSVL.xlsx";
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('Không có dữ liệu');window.location.href = '/Strongparameters'</script>";
                        return View(TempData);
                    }
            
            }
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('" + ex.Message + "');window.location.href = '/Strongparameters'</script>";
                return View(TempData);
            }

        }
    }
}