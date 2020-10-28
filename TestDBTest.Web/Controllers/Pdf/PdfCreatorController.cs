using Abp.Domain.Repositories;
using Abp.Web.Mvc.Controllers;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using TestDBTest.Services;
using TestDBTest.Services.OfficialGazette;
using TestDBTest.Services.OfficialGazzet;
using TestDBTest.Services.OfficialGazzet.Dto;
using TestDBTest.Web.Models;


namespace TestDBTest.Web.Controllers.Pdf
{
	[System.Web.Http.Route("api/pdfcreator")]
	public class PdfCreatorController : Controller
	{
		private IConverter _converter;

        public IOfficialGazzeteAppService OfficialGazettePdf { get; }

        public PdfCreatorController(IConverter converter, IOfficialGazzeteAppService officialGazettePdf)
		{
			_converter = converter;
            OfficialGazettePdf = officialGazettePdf;
        }
		//public async Task<ActionResult> Index()
		//{
		//	var model = new OfficialGazzeteWithListsDto();
		//	model.Gazzetes = await OfficialGazettePdf.GetAllAsync();

		//	return View(model);
		//}
		[System.Web.Http.HttpGet]
		public ActionResult CreatePDF()
		{
			
			var pdf = new HtmlToPdfDocument()
			{
				//GlobalSettings = globalSettings,
				//Objects = { objectSettings }
				GlobalSettings = {
						ColorMode = ColorMode.Color,
						Orientation = Orientation.Portrait,
						PaperSize = PaperKind.A4,
						Margins = new MarginSettings { Top = 10 },
						DocumentTitle = "PDF Report"
						//Out = @"C:\Users\HP-DEV1\Desktop\People_Report.pdf"
				},

				Objects = {
					new ObjectSettings()
					{
						Page = "http://localhost:6234/#/gazette", 
					}
				}
			};
			//var file = _converter.Convert(pdf);

			//return Ok("Successfully created PDF document.");
			//return File(file, "application/pdf");
			byte[] pdf_ = _converter.Convert(pdf);


			return new FileContentResult(pdf_, "application/pdf");
		}
	}
}