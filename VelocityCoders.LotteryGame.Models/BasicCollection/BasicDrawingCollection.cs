using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Susie.Common;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Collections;

namespace VelocityCoders.LotteryGame.Models.BasicCollection
{
    public class BasicDrawingCollection : BaseCollection<BasicDrawing>
    {
        private int drawingId;
        private int lotteryId;
        public BasicWinningNumber number;

        public BasicDrawingCollection()
        {
        }

        public BasicDrawingCollection(int drawingId, int lotteryId)
        {
            this.drawingId = drawingId;
            this.lotteryId = lotteryId;
        }

        public BasicDrawingCollection(BasicWinningNumber number)
        {
            this.number = number;
        }

    }
}

