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
    public class FriendLinkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FriendLinkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/FriendLink
        public async Task<IActionResult> Index()
        {
            return View(await _context.FriendLinks.ToListAsync());
        }

        // GET: Admin/FriendLink/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendLink = await _context.FriendLinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friendLink == null)
            {
                return NotFound();
            }

            return View(friendLink);
        }

        // GET: Admin/FriendLink/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FriendLink/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,SiteUrl,ImgUrl,SortId,AddTime")] FriendLink friendLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friendLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(friendLink);
        }

        // GET: Admin/FriendLink/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendLink = await _context.FriendLinks.FindAsync(id);
            if (friendLink == null)
            {
                return NotFound();
            }
            return View(friendLink);
        }

        // POST: Admin/FriendLink/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,SiteUrl,ImgUrl,SortId,AddTime")] FriendLink friendLink)
        {
            if (id != friendLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendLinkExists(friendLink.Id))
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
            return View(friendLink);
        }

        // GET: Admin/FriendLink/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendLink = await _context.FriendLinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friendLink == null)
            {
                return NotFound();
            }

            return View(friendLink);
        }

        // POST: Admin/FriendLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var friendLink = await _context.FriendLinks.FindAsync(id);
            _context.FriendLinks.Remove(friendLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendLinkExists(int id)
        {
            return _context.FriendLinks.Any(e => e.Id == id);
        }
    }
}
