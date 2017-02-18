using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomOffline.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int PlayerInGameId { get; set; }

        public DateTime CreateDateTime { get; set; }
        public decimal Amount { get; set; }
        public string AdditionInfo { get; set; }

        public virtual PaymentType Type { get; set; }
        public virtual PlayerInGame PlayerInGame { get;set; }
    }
}