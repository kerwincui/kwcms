using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kewcms.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int MessageCount { get; set; }

        public int AdminCount { get; set; }

        public int ArticleCount { get; set; }

        public List<Article> Articles { get; set; }

        public BaseInfo BaseInfo { get; set; }

        public ServerInfo ServerInfo { get; set; }
    }
}