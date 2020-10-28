using System.IO;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using TestDBTest.Web.Models;


namespace TestDBTest.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TestDBTestControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }

      
    }
}