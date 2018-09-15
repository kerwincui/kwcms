using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kewcms.Areas.Admin.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "请填写标题")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "字符长度只能在3-100之间")]
        [DisplayName("标题")]
        public string Title { get; set; }

        [DisplayName("副标题")]
        public string SubTitle { get; set; }

        [DisplayName("图片")]
        [DataType(DataType.ImageUrl)]
        public string ImgUrl { get; set; }

        [DisplayName("摘要")]
        [DataType(DataType.MultilineText)]
        public string Zhaiyao { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("内容")]
        [Required(ErrorMessage="请输入内容")]
        public string Content { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "字符长度只能在2-100之间")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "必须由字母或者是数字组成")]
        [DisplayName("调用名称")]
        public string CallIndex { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("备注")]
        public string Remark { get; set; }

        [DisplayName("SEO标题")]
        public string SeoTitle { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("SEO关键词")]
        public string SeoKeyword { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("SEO描述")]
        public string SeoDescription { get; set; }

        [DisplayName("浏览数")]
        public int? Click { get; set; }

        [DisplayName("作者")]
        [Editable(false)]
        public string Author { get; set; }

        [DisplayName("标签")]
        public string Tag { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("添加时间")]
        public DateTime? AddTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("修改时间")]
        public DateTime? UpdateTime { get; set; }

        [DisplayName("分类名称")]
        public virtual ArticleCategory ArticleCategory { get; set; }
    }
}