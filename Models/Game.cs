using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomOffline.Models
{
    public class Game
    {
        public Game()
        {
            Start = DateTime.Now;
        }

        public int Id { get; set; }
        
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Начало")]
        public DateTime Start { get; set; }

        [Display(Name = "Конец")]
        public DateTime? End { get; set; }
        
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Rake> Rakes { get; set; }
    }
}