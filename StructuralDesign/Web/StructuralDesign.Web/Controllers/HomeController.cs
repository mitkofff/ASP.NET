namespace StructuralDesign.Web.Controllers
{
    using System;
    using System.Diagnostics;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Web.ViewModels;
    using StructuralDesign.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly Cloudinary cloudinary;

        public HomeController(
            IGetCountsService countsService,
            IWebHostEnvironment hostingEnvironment, 
            Cloudinary cloudinary)
        {
            this.countsService = countsService;
            this.hostingEnvironment = hostingEnvironment;
            this.cloudinary = cloudinary;
        }

        public IActionResult Index()
        {
            Debug.WriteLine(this.hostingEnvironment.EnvironmentName);
            var countsDto = this.countsService.GetCounts();
            var viewModel = new IndexViewModel
            {
                CountOfBooks = countsDto.CountOfBooks,
                CountOfCategories = countsDto.CountOfCategories,
                CountOfProjects = countsDto.CountOfProjects,
                CountOfRegistratedUsers = countsDto.CountOfRegistratedUsers,
                CountOfSections = countsDto.CountOfSections,
            };

            return this.View(viewModel);
        }

        public IActionResult DataDemo(int id, string name, DateTime time)
        {
            return this.Json(new { id, name, time });
        }

        public IActionResult AJAXDemo()
        {
            return this.View();
        }

        public IActionResult AjaxDemoData()
        {
            return this.Json(new[]
            {
                new { Name= "Niki2", Date = DateTime.UtcNow.ToString("O") },
                new { Name = "Mit", Date = DateTime.UtcNow.AddDays(1).ToString("O") },
                new { Name = "Mit2", Date = DateTime.UtcNow.AddDays(2).ToString("O") },
            });
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
