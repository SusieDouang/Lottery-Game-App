using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Susie.Common;


namespace VelocityCoders.LotteryGame.Models
{
    public class BasicDrawing : Base
    {
        public int DrawingId { get; set; }
        public int LotteryId { get; set; }
        public DateTime DrawingDate { get; set; }
        public int Jackpot { get; set; }

        public BasicLottery BasicLottery { get; set; }
        public BasicWinningNumber BasicWinningNumber { get; set; }
        public BasicBallType BasicBallType { get; set; }

        public BasicDrawing()
        {
            this.BasicLottery = new BasicLottery();
            this.BasicWinningNumber = new BasicWinningNumber();
            this.BasicBallType = new BasicBallType();
        }

        public BasicDrawing(int drawingId, int lotteryId)
        {
            DrawingId = drawingId;
            LotteryId = lotteryId;
        }
    }
}
