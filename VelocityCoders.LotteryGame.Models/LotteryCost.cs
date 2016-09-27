using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryGame.Models
{
    public class LotteryCost
    {
        public int LotteryCostId { get; set; }
        public int LotteryId { get; set; }
        public int Cost { get; set; }

    }
}
