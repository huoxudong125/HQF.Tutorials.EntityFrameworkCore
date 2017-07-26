using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.Domains
{
    public class Base
    {
        public int Id { get; set; }

        [Display(Name = "创建时间", Order = 98)]
        public DateTime CreateTime { get; set; }

        [Display(Name = "更新时间", Order = 99)]
        public DateTime UpdateTime { get; set; }

    }
}
