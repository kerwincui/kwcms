using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace kewcms.Areas.Admin.Models {
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser {

        [DisplayName("真实姓名")]
        [MaxLength(10)]
        public string RealName { get; set; }

        [DisplayName("备注")]
        [MaxLength(128)]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        [DisplayName("头像")]
        [DataType(DataType.ImageUrl)]
        [MaxLength(256)]
        public string Pic { get; set; }
    }

    public partial class Role : IdentityRole {

        public Role() : base() { }

        public Role(string name) : base(name) { }

        [DisplayName("中文名称")]
        public string ChnName { get; set; }

    }
}
