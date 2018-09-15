using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using kewcms.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Diagnostics;
using kewcms.Data;
using Microsoft.AspNetCore.Identity;

namespace kewcms.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller {

        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext dbContext;

        public HomeController(UserManager<ApplicationUser> _userManager, ApplicationDbContext _dbContext) {
            userManager = _userManager;
            dbContext = _dbContext;
        }

        [Area("admin")]
        public IActionResult Index() {
            DashboardViewModel model = new DashboardViewModel();
            model.BaseInfo = GetSiteInfo();
            model.ServerInfo = GetServerInfo();
            model.Articles=new List<Article>();
            model.AdminCount = userManager.Users.Count();
            model.ArticleCount = dbContext.Articles.Count();
            model.MessageCount = dbContext.Feedbacks.Count();
            return View(model);
        }

        #region help method
        //获取站点信息
        public BaseInfo GetSiteInfo()
        {
            BaseInfo info = new BaseInfo();
            XDocument site = XDocument.Load(AppContext.BaseDirectory + "/site.xml");
            XElement siteInfo = site.Element("site");
            if (siteInfo != null)
            {
                info.Domain = siteInfo.Element("domain")?.Value;
                info.Name = siteInfo.Element("name")?.Value;
                info.Logo = siteInfo.Element("logo")?.Value;
                info.Company = siteInfo.Element("company")?.Value;
                info.Address = siteInfo.Element("address")?.Value;
                info.Tel = siteInfo.Element("tel")?.Value;
                info.Fax = siteInfo.Element("fax")?.Value;
                info.Email = siteInfo.Element("email")?.Value;
                info.Crod = siteInfo.Element("crod")?.Value;
                info.Copyright = siteInfo.Element("copyright")?.Value;
                info.Kefu = siteInfo.Element("kefu")?.Value;
                info.CountCode = siteInfo.Element("countCode")?.Value;
                info.WebClick = siteInfo.Element("webClick")?.Value;
                info.SeoTitle = siteInfo.Element("seoTitle")?.Value;
                info.SeoKeywords = siteInfo.Element("seoKeywords")?.Value;
                info.SeoDescription = siteInfo.Element("seoDescription")?.Value;
            }
            return info;
        }

        //获取服务器信息
        public ServerInfo GetServerInfo()
        {
            ServerInfo info = new ServerInfo();
            var process = Process.GetCurrentProcess();
            info.ServerName = process.MachineName;
            //info.ServerIp=process
            //info.ServerIp = Request.ServerVariables.Get("Local_Addr").ToString();
            //info.ServerSystem = Environment.OSVersion.ToString();
            //info.ServerPath = Request.PhysicalApplicationPath;
            //info.ServerIIs = Request.ServerVariables["SERVER_SOFTWARE"].ToString();
            //info.ServerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Version Vector");
            //info.NetVersion = Environment.Version.ToString();
            //info.ServerPort = Request.ServerVariables.Get("Server_Port").ToString();
            return info;
        }
        #endregion

    }
}