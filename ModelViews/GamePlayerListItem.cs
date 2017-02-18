using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomOffline.ModelViews
{
    public class GamePlayerListItem
    {
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Вход")]
        public string Input { get; set; }

        [Display(Name = "Выход")]
        public string Out { get; set; }
    }
}