using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.Domains
{
    public class WorkArea:Base
    {

        [Display(Name = "名称")]

        public string Name { get; set; }

        [Display(Name = "位置")]
        public string Position { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }

        public int ProjectId { get; set; }

        [Display(Name = "项目名称")]
        public Project Project { get; set; }

        /// <summary>
        ///  工程项列表
        /// </summary>
        public List<WorkItem> WorkItems { get; set; }

    }
}
