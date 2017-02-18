using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomOffline.ModelViews
{
    public class GameSpendingListItem
    {
        [Display(Name = "Куда")]
        public string Use { get; set; }

        [Display(Name = "Сколько")]
        public string Amount { get; set; }
    }
}