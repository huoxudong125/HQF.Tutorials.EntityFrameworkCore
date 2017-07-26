using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.Domains
{
    /// <summary>
    /// 工程类型
    /// </summary>
    public class WorkType:Base
    {
        [Display(Name = "名称")]
        public string Name { get; set; }

       
        public int? ParentId { get; set; }

        [Display(Name ="描述")]
        public string Description { get; set; }

        [Display(Name = "父级项目")]
        [DisplayFormat(NullDisplayText = "------")]
        public  WorkType ParentWorkType { get; set; }

        /// <summary>
        /// 工程项目单元集
        /// </summary>
        public List<WorkTypeUnit> WorkTypeUnits { get; set; }

        public List<WorkType> SubWorkTypes { get; set; }
        
        
        /// <summary>
        ///  工程项列表
        /// </summary>
        public List<WorkItem> WorkItems { get; set; }

        /// <summary>
        /// 报价列表
        /// </summary>
        public List<WorkItemPrice> WorkItemPrices { get; set; }

    }
}
