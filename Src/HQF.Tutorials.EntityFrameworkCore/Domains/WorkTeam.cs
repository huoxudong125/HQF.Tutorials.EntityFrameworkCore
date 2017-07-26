using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.Domains
{
    public class WorkTeam:Base
    {
     
        [Display(Name="名称")]
        public string Name { get; set; }

        [Display(Name = "全名")]
        public string FullName { get; set; }

        [Display(Name = "电话")]
        public string TelPhone { get; set; }

        [Display(Name = "手机")]
        public string MobilePhone { get; set; }


        /// <summary>
        /// 合同名称
        /// </summary>
        [Display(Name = "合同名称")]
        public string ContractName { get; set; }


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
