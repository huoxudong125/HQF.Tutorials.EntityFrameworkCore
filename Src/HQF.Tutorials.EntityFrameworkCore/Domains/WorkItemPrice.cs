using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.Domains
{
    /// <summary>
    /// 同一项目会有好几种单位的单价
    /// </summary>
    public class WorkItemPrice : Base
    {
        /// <summary>
        /// 以分为单位
        /// </summary>
        [Display(Name = "单价")]
        public int Price { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

   

        public int WorkTeamId { get; set; }


        public int WorkTypeUnitId { get; set; }


        public int WorkItemId { get; set; }



        [Display(Name = "计量单位")]
        public WorkTypeUnit WorkTypeUnit { get; set; }


        /// <summary>
        /// 工作项目
        /// </summary>
        [Display(Name = "工程名", Order = 1)]
        public WorkItem WorkItem { get; set; }

        /// <summary>
        /// 责任工队
        /// </summary>
        [Display(Name = "劳务队", Order = 2)]
        public WorkTeam WorkTeam { get; set; }


        public List<WorkItemProgress> WorkItemProgresses { get; set; }


    }
}
