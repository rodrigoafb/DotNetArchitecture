using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Solution.Application.Applications;
using Solution.CrossCutting.AspNetCore.Attributes;
using Solution.CrossCutting.AspNetCore.Extensions;
using Solution.Model.Models;

namespace Solution.Web.App
{
    [ApiController]
    [RouteController]
    public class FileServiceController : ControllerBase
    {
        public FileServiceController(IHostingEnvironment environment, IFileApplication fileApplication)
        {
            Directory = Path.Combine(Environment.ContentRootPath, "Files");
            Environment = environment;
            FileApplication = fileApplication;
        }

        private string Directory { get; }

        private IHostingEnvironment Environment { get; }

        private IFileApplication FileApplication { get; }

        [HttpGet]
        [RouteAction]
        public IActionResult Download(string fileName)
        {
            var bytes = FileApplication.Bytes(Directory, fileName);
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out var contentType);
            return File(bytes, contentType, fileName);
        }

        [DisableRequestSizeLimit]
        [HttpPost]
        [RouteAction]
        public IEnumerable<FileModel> Upload()
        {
            return FileApplication.Save(Directory, Request.Files());
        }
    }
}
