﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomOffline.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Display(Name = "Название игры")]
        public int GameId { get; set; }

        [Display(Name = "Человек")]
        public int PersonId { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Game Game { get; set; }
        public virtual Person Person { get; set; }
    }
}