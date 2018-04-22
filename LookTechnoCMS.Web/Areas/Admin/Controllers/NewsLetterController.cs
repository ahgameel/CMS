using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using ClosedXML;
using ClosedXML.Excel; 
using System.Web.Mvc;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.NewsletterSubscriberService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class NewsLetterController : BaseController
    {
        private readonly ISubscribersService _subscribersService;

        public NewsLetterController(ISubscribersService subscribersService)
        {
            _subscribersService = subscribersService;
        }
        // GET: Admin/NewsLetter
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult ExportToExcel()
        {
           
            var subscribers = _subscribersService.GetSubscribers();
            var dt = ConvertToDataTable(subscribers);
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Subscribers.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            return RedirectToAction("Index", "NewsLetter");  
        }
        public ActionResult GetSubscribers([DataSourceRequest] DataSourceRequest request)
        {
            var subscribers = _subscribersService.GetSubscribers();
            var subscribersViewModel = Mapper.Map<IEnumerable<NewsletterSubscriber>, IEnumerable<SubscribersViewModel>>(subscribers);
            return Json(subscribersViewModel.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
       
        DataTable ConvertToDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();
            dt.TableName = "Subscribers";
            dt.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name, Nullable.GetUnderlyingType(
            p.PropertyType) ?? p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }
 
    }
}