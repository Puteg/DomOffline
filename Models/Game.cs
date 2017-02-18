using System;
using System.Collections.Generic;

namespace DomOffline.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        public virtual ICollection<PlayerInGame> PlayerInGames { get; set; }
    }
}