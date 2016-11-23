using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Susie.Common;

namespace VelocityCoders.LotteryGame.Models
{
    public class BasicWinningNumber : Base
    {
        public int WinningNumberId { get; set; }
        public int DrawingId { get; set; }
        public int BallTypeId { get; set; }
        public int Number { get; set; }
   
        public BasicBallType BasicBallType { get; set; }
       

        public BasicWinningNumber()
        {
            this.BasicBallType = new BasicBallType();
        }

    }
}
