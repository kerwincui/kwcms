using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kewcms.Areas.Admin.Models {

    public class VisitorInfo
    {
        public long Id { get; set; }

        [DisplayName("名称")]
        public string VisitorIp { get; set; }

        [DisplayName("城市ID")]
        public string CityId { get; set; }

        [DisplayName("城市名称")]
        public string CityName { get; set; }

        [DisplayName("访问页面")]
        public string VisitUrl { get; set; }

        [DisplayName("访问设备")]
        public string AppVersion { get; set; }

        [DisplayName("添加时间")]
        public string AddTime { get; set; }
    }
}