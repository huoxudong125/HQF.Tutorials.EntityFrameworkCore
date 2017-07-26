using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.Domains
{
    public class WorkTypeUnit:Base
    {
        public int WorkTypeId { get; set; }
        public int WorkUnitId { get; set; }

        [Display(Name="工程类型")]
        public  WorkType WorkType { get; set; }

        [Display(Name = "工程单位")]
        public  WorkUnit WorkUnit { get; set; }

        /// <summary>
        /// 报价列表
        /// </summary>
        public List<WorkItemPrice> WorkItemPrices { get; set; }
    }
}
