using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomOffline.ModelViews
{
    public class GameRakeListItem
    {
        [Display(Name = "Сумма")]
        public string Amount { get; set; }

        [Display(Name = "Время")]
        public string DateTime { get; set; }

        [Display(Name = "Дилер")]
        public string Diler { get; set; }
    }
}