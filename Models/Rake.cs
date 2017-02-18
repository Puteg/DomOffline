using System;
using System.ComponentModel.DataAnnotations;

namespace DomOffline.Models
{
    public class Rake
    {
        public Rake()
        {
            DateTime = DateTime.Now;
        }

        public int Id { get; set; }

        [Display(Name = "Игра")]
        public int GameId { get; set; }

        [Display(Name = "Человек")]
        public int PersonId { get; set; }

        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Game Game { get; set; }
        public virtual Person Person { get; set; }
    }
}