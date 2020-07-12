using System;
using System.Collections.Generic;
using System.Web.Http;
using System.IO;
using InsertToForm.Models;
using InsertToForm.UtilCode;
using System.Linq;

/// <summary>
/// Контроллер для заполнения клиентских данных в формы, которые находятся в папке Resources,
/// после чего сохраняются в папке Documents
/// </summary>
namespace InsertToForm.Controllers
{
    public class FormsController : ApiController
    {
        static string pathFolderTemplates = AppDomain.CurrentDomain.BaseDirectory + "Resources\\";
        static string pathFolderDirectories = AppDomain.CurrentDomain.BaseDirectory + "Documents\\";
        List<string> templatesList = Directory.GetFiles(pathFolderTemplates).ToList<string>();
        List<string> foldersList = Directory.GetDirectories(pathFolderDirectories).ToList<string>();

        // GET api/values
        public List<string>[] Get()
        {
            int some = 0;
            Console.WriteLine(templatesList[some]);

            List<string>[] responseArray = new List<string>[2];
            responseArray[0] = templatesList;
            responseArray[1] = foldersList;
            return responseArray;
        }

        public string Post([FromBody] ClientInfo client)
        {
            DataValid dv = new DataValid();
            if (!dv.IsValidDatas(client.LastName, client.FirstName, client.MiddleName, client.BirthDate, client.LoanSum))
                return "Проверьте правильность введённых данных";

            DateTime currentDate = DateTime.Now;
            string pathTemplate = templatesList[client.TemplateNum];

            string pathOutputFolder = foldersList[client.FolderNum];
            if (!Directory.Exists(pathOutputFolder)) return "Папка не найдена, обратитесь к администратору или выберите другую";

            string templateName = templatesList[client.TemplateNum].Remove(0, templatesList[client.TemplateNum].LastIndexOf("\\"));
                templateName = templateName.Remove(templateName.IndexOf("."));
            string newFileName = templateName + " " + client.FirstName + " " + client.LastName + " от " + currentDate.ToLongDateString().Replace(".", "") + ".docx";
            string pathNewFile = pathOutputFolder + newFileName;

            Replacer repl = new Replacer();
            return repl.NewDoc(pathTemplate, pathNewFile, client.LastName, client.FirstName, client.MiddleName, client.BirthDate, client.LoanSum, client.Image);
        }
    }
}
