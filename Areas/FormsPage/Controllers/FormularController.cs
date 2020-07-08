using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using InsertToForm.Controllers;
using InsertToForm.UtilCode;

namespace InsertToForm.Areas.FormsPage.Controllers
{
    public class FormularController : Controller
    {

        // GET: FormsPage/Formular
        public ActionResult Index()
        {
            return View("~/Areas/FormsPage/Views/Formular/Index.cshtml");
        }

        public FileResult GetFile(string pathFile)
        {
            string file_path = Server.MapPath("~/Documents/" + pathFile);
            string file_type = "application/docx";
            string file_name = pathFile.Substring(pathFile.LastIndexOf('\\')+1); ;
            return File(file_path, file_type, file_name);
        }

        public FileResult PrintFile(string pathFile)
        {
            string doc_path = Server.MapPath("~/Documents/" + pathFile);
            Converter conv = new Converter();
            string pdf_path = conv.ConvertFile(doc_path);

            string pdf_type = "application/pdf";
            string pdf_name = pdf_path.Substring(pdf_path.LastIndexOf('\\') + 1);
            return File(pdf_path, pdf_type, pdf_name);
        }

        public void Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                //string fileName = System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Documents/" + "inputImage.jpg"));
            }
        }
    }
}