using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kewcms.Areas.Admin.Models;
using kewcms.Data;

namespace kewcms.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VisitorInfoController : Controller
    {
        private readonly ApplicationDbContext context;

        public VisitorInfoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Admin/VisitorInfoes
        public async Task<IActionResult> Index()
        {
            return View(await context.VisitorInfos.ToListAsync());
        }

        // POST: Admin/VisitorInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VisitorIp,CityId,CityName,VisitUrl,AppVersion,AddTime")] VisitorInfo visitorInfo)
        {
            if (ModelState.IsValid)
            {
                context.Add(visitorInfo);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitorInfo);
        }
    }
}
