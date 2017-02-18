using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomOffline.Models
{
    public class PlayerInGame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}