using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryGame.Models
{
    public class WinningNumber : Lottery
    {
        public int LotteryId { get; set; }
        public int WinningNumberId { get; set; }
        public int DrawingId { get; set; }
        public int BallTypeId { get; set; }
        public int Number { get; set; }

        public Drawing Drawing { get; set; }
        public DateTime DrawingDate { get; set; }

    }
}
