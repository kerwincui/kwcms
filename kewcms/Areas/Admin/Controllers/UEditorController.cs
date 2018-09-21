using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UEditor.Core;
using UEditor.Core.Handlers;

namespace kewcms.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class UEditorController : Controller
    {

        private readonly UEditorService ueditorService;
        private readonly IHostingEnvironment hostingEnvironment;

        public UEditorController(UEditorService ueditorService, IHostingEnvironment env)
        {
            this.ueditorService = ueditorService;
            hostingEnvironment = env;
        }

        //如果是API，可以按MVC的方式特别指定一下API的URI
        [HttpGet, HttpPost]
        public ContentResult Upload()
        {
            var response = ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }

        [HttpPost]
        public ActionResult UploadImg(IFormCollection files)
        {
            var result = new UploadResult();

            foreach (var item in files.Files)
            {
                string path= "/upload/image/"+ DateTime.Now.ToString("yyyyMMdd") + "/";
                string localPath = hostingEnvironment.ContentRootPath + path;
                if (!System.IO.Directory.Exists(localPath))
                {
                    System.IO.Directory.CreateDirectory(localPath);
                }
                var suffix = item.FileName.Substring(item.FileName.LastIndexOf("."));
                var fileName = Guid.NewGuid().ToString("N") + suffix;
                item.CopyTo(new FileStream(localPath + fileName, FileMode.Create));
                result.Url = path + fileName;
                result.OriginFileName = item.FileName;
            }
            return Json(result);
        }

    }

}