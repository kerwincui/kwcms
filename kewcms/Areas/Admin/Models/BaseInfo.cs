using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kewcms.Areas.Admin.Models {

    public class BaseInfo
    {
        [DisplayName("域名")]
        public string Domain { get; set; }
        [DisplayName("网站名称")]
        public string Name { get; set; }
        [DisplayName("标志图")]
        public string Logo { get; set; }
        [DisplayName("公司名称")]
        public string Company { get; set; }
        [DisplayName("地址")]
        public string Address { get; set; }
        [DisplayName("电话")]
        public string Tel { get; set; }
        [DisplayName("传真")]
        public string Fax { get; set; }
        [DisplayName("邮箱")]
        public string Email { get; set; }
        [DisplayName("备案号")]
        public string Crod { get; set; }
        [DisplayName("版权")]
        public string Copyright { get; set; }
        [DisplayName("客服")]
        public string Kefu { get; set; }
        [DisplayName("统计代码")]
        [DataType(DataType.MultilineText)]
        public string CountCode { get; set; }
        [DisplayName("网站访问量")]
        public string WebClick { get; set; }
        [DisplayName("SEO标题")]
        public string SeoTitle { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("SEO描述")]
        public string SeoDescription { get; set; }
        [DisplayName("SEO关键词")]
        public string SeoKeywords { get; set; }
    }

    public class ServerInfo
    {
        public string ServerName { get; set; }

        public string ServerIp { get; set; }

        public string ServerIIs { get; set; }

        public string ServerPort { get; set; }

        public string ServerTime { get; set; }

        public string ServerSystem { get; set; }

        public string ServerPath { get; set; }

        public string NetVersion { get; set; }
    }

}