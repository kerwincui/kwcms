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
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext context;

        public FeedbackController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Admin/Feedbacks
        public async Task<IActionResult> Index()
        {
            return View(await context.Feedbacks.ToListAsync());
        }

        public async Task<IActionResult> NewMessage()
        {
            return PartialView("_NewMessage",
                await context.Feedbacks.Where(x => String.IsNullOrWhiteSpace(x.ReplayContent)).ToListAsync());
        }

        // GET: Admin/Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return View(new Feedback());
            }

            var feedback = await context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // POST: Admin/Feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Name,Tel,QQ,Email,AddTime,ReplayContent,ReplayTime")] Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        feedback.AddTime = DateTime.Now;
                        context.Add(feedback);
                    }
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(feedback.ReplayContent))
                        {
                            feedback.ReplayTime = DateTime.Now;
                        }
                        context.Update(feedback);
                    }
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        // POST: Admin/Feedbacks/Delete/5
        [HttpPost,]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var feedback = await context.Feedbacks.FindAsync(id);
            context.Feedbacks.Remove(feedback);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
            return context.Feedbacks.Any(e => e.Id == id);
        }
    }
}
