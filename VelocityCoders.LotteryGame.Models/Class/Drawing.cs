using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.LotteryGame.Models;
namespace VelocityCoders.LotteryGame.Models
{
    public class Drawing : Lottery
    {

        public int DrawingId { get; set; }
        public DateTime DrawingDate { get; set; }
        public int Jackpot { get; set; }

        public BallType BallType { get; set; }
        public WinningNumber WinningNumber { get; set; }

       public Drawing()
        {
            this.BallType = new BallType();
            this.WinningNumber = new WinningNumber();

        }
    }
}
