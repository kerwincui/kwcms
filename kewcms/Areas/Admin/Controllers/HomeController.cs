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
    [Area("admin")]
    public class HomeController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;

        public HomeController(UserManager<ApplicationUser> _userManager, ApplicationDbContext _dbContext)
        {
            userManager = _userManager;
            dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            model.BaseInfo = GetSiteInfo();
            model.ServerInfo = GetServerInfo();
            model.Articles = new List<Article>();
            model.AdminCount = userManager.Users.Count();
            model.ArticleCount = dbContext.Articles.Count();
            model.MessageCount = dbContext.Feedbacks.Count();
            return View(model);
        }

        //网站基本信息
        public ActionResult BaseInfo()
        {
            BaseInfo model = GetSiteInfo();
            return View(model);
        }

        [HttpPost]
        public ActionResult BaseInfo(BaseInfo info)
        {
            XDocument site = XDocument.Load(AppContext.BaseDirectory + "/site.xml");
            XElement siteInfo = site.Element("site");
            siteInfo.Element("domain").Value = info.Domain ?? "";
            siteInfo.Element("name").Value = info.Name ?? "";
            siteInfo.Element("logo").Value = info.Logo ?? "";
            siteInfo.Element("company").Value = info.Company ?? "";
            siteInfo.Element("address").Value = info.Address ?? "";
            siteInfo.Element("tel").Value = info.Tel ?? "";
            siteInfo.Element("fax").Value = info.Fax ?? "";
            siteInfo.Element("email").Value = info.Email ?? "";
            siteInfo.Element("crod").Value = info.Crod ?? "";
            siteInfo.Element("copyright").Value = info.Copyright ?? "";
            siteInfo.Element("kefu").Value = info.Kefu ?? "";
            siteInfo.Element("countCode").Value = info.CountCode ?? "";
            siteInfo.Element("webClick").Value = info.WebClick ?? "";
            siteInfo.Element("seoTitle").Value = info.SeoTitle ?? "";
            siteInfo.Element("seoKeywords").Value = info.SeoKeywords ?? "";
            siteInfo.Element("seoDescription").Value = info.SeoDescription ?? "";
            siteInfo.Save(AppContext.BaseDirectory + "/site.xml");
            return View(info);
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