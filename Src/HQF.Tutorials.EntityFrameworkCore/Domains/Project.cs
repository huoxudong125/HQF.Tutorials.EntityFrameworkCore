using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.Domains
{
    public class Project:Base
    {
      


        /// <summary>
        /// 名称
        /// </summary>
       [Display(Name="名称")]
        public string Name { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name = "描述")]
        public string Decription { get; set; }


        /// <summary>
        /// 工区
        /// </summary>
        public List<WorkArea> WorkAreas { get; set; }

    }
}
