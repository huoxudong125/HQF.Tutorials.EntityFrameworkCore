using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.Domains
{
    public class WorkItemProgress:Base
    {
        //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model
        [Display(Name ="日期",Order =3)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CurrentDate { get; set; }

      
        public int WorkItemPriceId { get; set; }


        /// <summary>
        /// 工作量
        /// </summary>
       [Display(Name ="当日工作量",Order =4)]
        public long WorkQuantity { get; set; }

      


        /// <summary>
        /// 工作项价格
        /// </summary>
        public  WorkItemPrice WorkItemPrice { get; set; }


      
    }
}
