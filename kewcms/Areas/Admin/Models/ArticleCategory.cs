using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kewcms.Areas.Admin.Models {

    public class ArticleCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage="请输入分类名称")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "字符长度只能在2-100之间")]
        [DisplayName("名称")]
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "字符长度只能在2-100之间")]
        [RegularExpression("^[A-Za-z0-9]+$",ErrorMessage="必须由字母或者是数字组成")]
        [DisplayName("调用名称")]
        public string CallIndex { get; set; }

        [DisplayName("SEO标题")]
        public string SeoTitle { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("SEO关键词")]
        public string SeoKeyword { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("SEO描述")]
        public string SeoDescription { get; set; }

        [DisplayName("分类描述")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("文章")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}