using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HQF.Daily.Web.Domains
{
    public class WorkUnit : Base
    {
        /// <summary>
        /// 单位名称
        /// </summary>
        [Display(Name = "No grade")]
        public string Name { get; set; }

        public List<WorkTypeUnit> WorkTypeUnits { get; set; }

        /// <summary>
        /// 报价列表
        /// </summary>
        public List<WorkItemPrice> WorkItemPrices { get; set; }
    }
}