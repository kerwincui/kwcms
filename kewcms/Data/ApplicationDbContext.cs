using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kewcms.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kewcms.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Role> IdentityRoles { get; set; }
        public DbSet<FriendLink> FriendLinks { get; set; }
        public DbSet<VisitorInfo> VisitorInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //指定生成的表名
            builder.Entity<Article>().ToTable("Article");
            builder.Entity<ArticleCategory>().ToTable("ArticleCategory");
            builder.Entity<Feedback>().ToTable("Feedback");
            builder.Entity<FriendLink>().ToTable("FriendLink");
            builder.Entity<VisitorInfo>().ToTable("VisitorInfo");
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
