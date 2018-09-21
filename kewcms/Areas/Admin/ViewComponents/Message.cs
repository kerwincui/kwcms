using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kewcms.Areas.Admin.Models;
using kewcms.Data;

namespace kewcms.Areas.Admin.ViewComponents
{
    public class MessageViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public MessageViewComponent(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var message = await db.Feedbacks.Where(x => string.IsNullOrWhiteSpace(x.ReplayContent)).ToListAsync();
            return View(message);
        }

    }
}
