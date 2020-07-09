/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;*/
using Microsoft.Office.Interop.Word;

/// <summary>
/// Конвертер docx to pdf, триальная версия. Оригинал стоит 539 $
/// </summary>
namespace InsertToForm.UtilCode
{
    public class Converter
    {
        public string ConvertFile (string pathDoc)
        {
            
            string parhPdf = pathDoc.Replace(".docx", ".pdf");
            //SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();
            //p.DocxToPdfConvertFile(pathDoc, parhPdf);

            Application appWord = new Application();
            var wordDocument = appWord.Documents.Open(pathDoc);
            wordDocument.ExportAsFixedFormat(parhPdf, WdExportFormat.wdExportFormatPDF);

            return parhPdf;
        }
    }
}