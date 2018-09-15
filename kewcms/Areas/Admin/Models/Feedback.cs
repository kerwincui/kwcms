using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kewcms.Areas.Admin.Models {

    public class Feedback
    {
        public int Id { get; set; }

        [DisplayName("留言标题")]
        [Required(ErrorMessage="请填写留言标题")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "字符长度只能在3-100之间")]
        public string Title { get; set; }

        [DisplayName("留言内容")]
        [Required(ErrorMessage="请填写留言内容")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [DisplayName("昵称")]
        public string Name { get; set; }

        [DisplayName("联系电话")]
        [Phone(ErrorMessage = "请输入正确的电话号码")]
        public string Tel { get; set; }

        [DisplayName("联系QQ")]
        public string QQ { get; set; }

        [DisplayName("邮箱")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("留言时间")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime? AddTime { get; set; }

        [DisplayName("回复内容")]
        [DataType(DataType.MultilineText)]
        public string ReplayContent { get; set; }

        [DisplayName("回复时间")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? ReplayTime { get; set; }
    }
}