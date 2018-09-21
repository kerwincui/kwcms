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
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext context;

        public ArticleController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Admin/Articles
        public async Task<IActionResult> Index()
        {
            return View(await context.Articles.ToListAsync());
        }

        // GET: Admin/Articles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0) {
                return View(new Article());
            }

            var article = await context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,SubTitle,ImgUrl,Zhaiyao,Content,CallIndex,Remark,SeoTitle,SeoKeyword,SeoDescription,Click,Author,Tag,AddTime,UpdateTime")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0) {
                        article.Author = User.Identity.Name;
                        article.AddTime = DateTime.Now;
                        context.Add(article);
                    }
                    else {
                        article.UpdateTime = DateTime.Now;
                        context.Update(article);
                    }
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
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
            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            context.Articles.Remove(article);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return context.Articles.Any(e => e.Id == id);
        }
    }
}
