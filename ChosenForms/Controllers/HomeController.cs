using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChosenForms.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace ChosenForms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider fileProvider;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IFileProvider fileprovider, IWebHostEnvironment env)
        {
            _logger = logger;
            fileProvider = fileprovider;
            hostingEnvironment = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]List<string> countries, [FromForm]List<string> options)
        {
            return View();
        }

        public IActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Feedback([Bind("Comment, File")]Feedback feedback)
        {
            if (feedback.File != null && feedback.File.Length != 0)
            {
                FileInfo fi = new FileInfo(feedback.File.FileName);
                var newFilename = DateTime.Now.Ticks.ToString() + fi.Extension;

                var webPath = hostingEnvironment.WebRootPath;
                var path = Path.Combine("", webPath + @"\ImageFiles\" + newFilename);
                var pathToSave = @"/ImageFiles/" + newFilename;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await feedback.File.CopyToAsync(stream);
                }
            }

            return View();
        }

        public IActionResult Images()
        {
            var imagePath = hostingEnvironment.WebRootPath + @"\ImageFiles\";
            var allFiles = Directory.GetFiles(imagePath).OrderByDescending(o => new Bitmap(o).Width).ThenByDescending(o => new Bitmap(o).Height).Select(o => "/ImageFiles/" + Path.GetFileName(o)).ToList();

            return View(allFiles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
