using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Конвертер docx to pdf, триальная версия. Оригинал стоит 539 $
/// </summary>
namespace InsertToForm.UtilCode
{
    public class Converter
    {
        public string ConvertFile (string pathDoc)
        {
            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();
            string parhPdf = pathDoc.Replace(".docx", ".pdf");

            p.DocxToPdfConvertFile(pathDoc, parhPdf);

            return parhPdf;
        }
    }
}