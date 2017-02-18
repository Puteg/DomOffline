using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomOffline.Models
{
    public class Payment
    {
        public Payment()
        {
            DateTime = DateTime.Now;
        }

        public int Id { get; set; }

        [Display(Name = "Тип платежа")]
        public int TypeId { get; set; }

        [Display(Name = "Игрок")]
        public int? PlayerId { get; set; }

        [Display(Name = "Игра")]
        public int GameId { get; set; }

        [Display(Name = "Назначение")]
        public PaymentUse PaymentUse { get; set; }
        public DateTime DateTime { get; set; }

        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        [Display(Name = "Дополнительная информация")]
        public string AdditionInfo { get; set; }

        public virtual PaymentType Type { get; set; }
        public virtual Player Player { get;set; }
        public virtual Game Game { get;set; }
    }

    public enum PaymentUse : byte
    {
        None = 0, 
        CashIn,
        CashOut,
        Bonus,
        Eat,
        Other
    }
}