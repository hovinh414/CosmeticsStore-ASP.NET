﻿using CosmeticsStore.Models;
using CosmeticsStore.Models.EF;
using Microsoft.Ajax.Utilities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeticsStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,StaffOrder, StaffBooking, StaffProductPostNew")]
    class Date
    {
        public static string FromDate;
        public static string ToDate;
    }
    public class StatisticalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Statistical
        public string FormatDateStart(string date)
        {
            string day = date.Substring(8, 2);
            string month = date.Substring(5,2);
            string year = date.Substring(0,4);
            date = day + "/" + month + "/" + year;
            return date;
        }
        public string FormatDateFinish(string date)
        {
            int x = Int32.Parse(date.Substring(8, 2)) + 1;
            string day = x.ToString();
            string month = date.Substring(5, 2);
            string year = date.Substring(0, 4);
            if(day.Length == 1)
            {
                date = "0" + day + "/" + month + "/" + year;
            }
            else
            {
                date = day + "/" + month + "/" + year;
            }
            return date;
        }
        public ActionResult Index(string fromDate, string toDate)
        {
            if(string.IsNullOrEmpty(fromDate) || string.IsNullOrEmpty(toDate))
            {
                Date.FromDate = "";
                Date.ToDate = "";
            }    
            else
            {
                Date.FromDate = FormatDateStart(fromDate);
                Date.ToDate = FormatDateFinish(toDate);
            }    
            return View();
        }

        [HttpPost]
        public ActionResult GetStatistical(string fromDate, string toDate)
        {
            fromDate = Date.FromDate;
            toDate = Date.ToDate;
            var query = from o in db.Orders
                        join od in db.OrderDetails
                        on o.Id equals od.OrderId
                        join p in db.Products
                        on od.ProductId equals p.Id
                        select new
                        {
                            CreatedDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                            OriginalPrice = p.OriginalPrice
                        };
            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime startDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate >= startDate);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate <= endDate);
            }
            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreatedDate)).Select(x => new
            {
                Date = x.Key.Value,
                TotalBuy = x.Sum(y => y.Quantity * y.OriginalPrice),
                TotalSell = x.Sum(y => y.Quantity * y.Price),
            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalSell,
                LoiNhuan = x.TotalSell - x.TotalBuy
            });
            return Json(new {Data = result},JsonRequestBehavior.AllowGet);
        }
        public void ExportExcel_EPPLUS()
        {

            var query = from o in db.Orders
                        join od in db.OrderDetails
                        on o.Id equals od.OrderId
                        join p in db.Products
                        on od.ProductId equals p.Id
                        select new
                        {
                            CreatedDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                            OriginalPrice = p.OriginalPrice
                        };
            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreatedDate)).Select(x => new
            {
                Date = x.Key.Value,
                TotalBuy = x.Sum(y => y.Quantity * y.OriginalPrice),
                TotalSell = x.Sum(y => y.Quantity * y.Price),
            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalSell,
                LoiNhuan = x.TotalSell - x.TotalBuy
            });


            ExcelPackage ep = new ExcelPackage();
            ExcelWorksheet Sheet = ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "STT";
            Sheet.Cells["B1"].Value = "Ngày";
            Sheet.Cells["C1"].Value = "Doanh Thu";
            Sheet.Cells["D1"].Value = "Lợi Nhuận";
            int row = 2;// dòng bắt đầu ghi dữ liệu
            int i = 1;
            foreach (var item in result)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = i;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.Date.ToString("dd/MM/yyyy");
                Sheet.Cells[string.Format("C{0}", row)].Value = item.DoanhThu;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.LoiNhuan;
                row++;
                i++;
            }
            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=" + "DoanhThu.xlsx");
            Response.BinaryWrite(ep.GetAsByteArray());
            Response.End();

        }

    }
}