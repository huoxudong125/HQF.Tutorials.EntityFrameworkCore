using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.Domains
{
    public class WorkItem : Base
    {
        public string Name { get; set; }

        [DisplayFormat(NullDisplayText = "--------")]
        public int? ParentId { get; set; }

        public int WorkTypeId { get; set; }

        public int WorkAreaId { get; set; }



        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 父级项目名
        /// </summary>

        public WorkItem ParentWorkItem { get; set; }


        /// <summary>
        /// 项目子集
        /// </summary>

        public List<WorkItem> SubWorkItems { get; set; }

        /// <summary>
        /// 工程类型
        /// </summary>
        public  WorkType WorkType { get; set; }

        /// <summary>
        /// 当前工区
        /// </summary>
        public  WorkArea WorkArea { get; set; }


        /// <summary>
        /// 报价列表
        /// </summary>
        public List<WorkItemPrice> WorkItemPrices { get; set; }

    }
}
