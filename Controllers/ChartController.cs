using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagerAssistant;
using ManagerAssistant.Data;
using Microsoft.Extensions.Logging;
using ManagerAssistant.Models;
using System.Drawing;
using System.Diagnostics;

namespace ManagerAssistant.Controllers
{
    public class ChartController : Controller
    {
        private readonly ILogger<ChartController> _logger;
        private readonly ApplicationDbContext _context;

        public ChartController(ILogger<ChartController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Chart
        public IActionResult Index()
        {
            var GetData = _context.Project.ToList();
            var model = new ProjectViewModel()  { Projects = GetData };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Send(ProjectViewModel model)
        {
            var project = new Project()
            {
                NameProject = model.ProjectsData.NameProject,
                TotalIncome = model.ProjectsData.TotalIncome
            };
            _context.Add(project);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetData()
        {
            var GetData = _context.Project.ToList();
            var random = new Random();
            var colors = new List<string>();
            for (int i = 0; i < GetData.Count; i++)
            {
                colors.Add(String.Format("#{0:X6}", random.Next(0x1000000)));
            }

            return Json(new { Status = true, Projects = GetData, colors });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
