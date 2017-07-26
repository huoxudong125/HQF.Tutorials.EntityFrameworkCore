using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.Domains
{
    public class Company:Base
    {

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "电话")]
        public string TelPhone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "微信")]
        public string WeChat { get; set; }

        [Display(Name = "手机")]
        public string MobilePhone { get; set; }

    }
}
