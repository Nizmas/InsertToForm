using System;
using System.Collections.Generic;
using System.Web.Http;
using System.IO;
using InsertToForm.Models;
using InsertToForm.UtilCode;
using DocumentFormat.OpenXml.Packaging;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Crypto.Engines;

/// <summary>
/// Контроллер для заполнения клиентских данных в формы, которые находятся в папке Resources,
/// после чего сохраняются в папке Documents
/// </summary>
namespace InsertToForm.Controllers
{
    public class FormsController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public string Post([FromBody] ClientInfo client)
        {
            DataValid dv = new DataValid();
            if (!dv.isValidDatas(client.LastName, client.FirstName, client.MiddleName, client.BirthDate, client.LoanSum))
                return "Проверьте правильность введённых данных";

            DateTime currentDate = DateTime.Now;
            string pathFolderTemplates = AppDomain.CurrentDomain.BaseDirectory + "Resources\\";
            string pathTemplate = pathFolderTemplates + client.TemplateName + ".docx";

            string pathOutputFolder = pathFolderTemplates.Replace("Resources", "Documents") + client.FolderName + "\\";
            if (!Directory.Exists(pathOutputFolder)) return "Папка не найдена, обратитесь к администратору или выберите другую";

            string newFileName = client.TemplateName + " " + client.FirstName + " " + client.LastName + " от " + currentDate.ToLongDateString().Replace(".", "") + ".docx";
            string pathNewFile = pathOutputFolder + newFileName;
            try
            {
                File.Copy(pathTemplate, pathNewFile, true);
            }
            catch
            {
                return "Шаблон не найден, проверьте правильность названия или обратитесь к администратору";
            }

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(pathNewFile, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                Replacer repl = new Replacer();
                docText = repl.newDoc(docText, client.LastName, client.FirstName, client.MiddleName, client.BirthDate, client.LoanSum);

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
            return pathNewFile;
        }
    }
}
