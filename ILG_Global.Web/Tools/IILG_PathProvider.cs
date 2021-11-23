using ILG_Global.BussinessLogic.Abstraction.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global.Web.Tools
{
    public class ILG_PathProvider: IILG_PathProvider
    {

        private IWebHostEnvironment _hostEnvironment;

        public ILG_PathProvider(IWebHostEnvironment environment)
        {
            _hostEnvironment = environment;
        }

        public string MapPath(string path)
        {
            string filePath = string.Format("{0}\\{1}", _hostEnvironment.WebRootPath, path);
            return filePath;
        }
    }
}
