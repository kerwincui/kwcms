using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kewcms.Areas.Admin.Models
{
    public class FriendLink
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "请填写标题")]
        [DisplayName("标题")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "字符长度只能在2-100之间")]
        public string Title { get; set; }

        [Required(ErrorMessage = "请填写链接地址")]
        [DisplayName("链接地址")]
        public string SiteUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        [DisplayName("图片")]
        public string ImgUrl { get; set; }

        [DisplayName("排序")]
        public int? SortId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("添加时间")]
        public DateTime? AddTime { get; set; }
    }
}