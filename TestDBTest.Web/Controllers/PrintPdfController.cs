using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestDBTest.Services.OfficialGazzet;
using TestDBTest.Services.OfficialGazzet.Dto;
using PdfSharp.Pdf;
using Rotativa;
using System.Linq.Dynamic.Core;
using IronPdf;
using Syncfusion.Pdf.Graphics;
using System.IO;

namespace TestDBTest.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PrintPdfController : Controller
    {

        [HttpPost]
        public ActionResult PrintPdf(List<OfficialGazzeteDto> data)
        {
            ViewData.Model = data;

            var sw = new StringWriter();

            var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, "PrintAll");

            var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);

            viewResult.View.Render(viewContext, sw);
            viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

            var Renderer = new IronPdf.HtmlToPdf();
            var pdfDoc = Renderer.RenderHtmlAsPdf(sw.GetStringBuilder().ToString());

            return File(pdfDoc.BinaryData, "print.pdf");
        }


    }
}