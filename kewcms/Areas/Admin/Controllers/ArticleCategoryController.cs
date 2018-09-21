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
    public class ArticleCategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public ArticleCategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Admin/ArticleCategory
        public async Task<IActionResult> Index()
        {
            return View(await context.ArticleCategories.ToListAsync());
        }

        // GET: Admin/ArticleCategory/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return View(new ArticleCategory());
            }

            var articleCategory = await context.ArticleCategories.FindAsync(id);
            if (articleCategory == null)
            {
                return NotFound();
            }
            return View(articleCategory);
        }

        // POST: Admin/ArticleCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CallIndex,SeoTitle,SeoKeyword,SeoDescription,Description")] ArticleCategory articleCategory)
        {
            if (id != articleCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0) {
                        context.Add(articleCategory);
                    }
                    else {
                        context.Update(articleCategory);
                    }
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleCategoryExists(articleCategory.Id))
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
            return View(articleCategory);
        }

        // POST: Admin/ArticleCategory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var articleCategory = await context.ArticleCategories.FindAsync(id);
            context.ArticleCategories.Remove(articleCategory);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleCategoryExists(int id)
        {
            return context.ArticleCategories.Any(e => e.Id == id);
        }
    }
}
