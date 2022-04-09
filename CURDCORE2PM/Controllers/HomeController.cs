using CURDCORE2PM.Dbcontent;
using CURDCORE2PM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CURDCORE2PM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            RcdbContext dbobj = new RcdbContext();

            var res = dbobj.Empdetails.ToList();
            List<empmodel> mobj = new List<empmodel>();
            foreach (var item in res)
            {
                mobj.Add(new empmodel
                {
                    Id=item.Id,
                    Name=item.Name,
                    Course=item.Course,
                    Mobile=item.Mobile,
                    Email=item.Email
                });

            }
            return View(mobj);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            RcdbContext db = new RcdbContext();
            var ditem = db.Empdetails.Where(m => m.Id == id).First();
            db.Empdetails.Remove(ditem);
            db.SaveChanges();
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
