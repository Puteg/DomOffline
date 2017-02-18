using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomOffline.Models;

namespace DomOffline.ModelViews
{
    public class GameVm
    {
        public Game Model { get; set; }
        public string RakeTotalAmount { get; set; }
        public string SpendingTotalAmount { get; set; }

        public string InputTotalAmount { get; set; }
        public string OutputTotalAmount { get; set; }

        public List<GameRakeListItem> RakeList { get; set; }
        public List<GameSpendingListItem> SpendingList { get; set; }
        public List<GamePlayerListItem> PlayerList { get; set; }
        
    }
}