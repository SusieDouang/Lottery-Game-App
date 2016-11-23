using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Susie.Common;

namespace VelocityCoders.LotteryGame.Models.Collections
{
    public class LotteryCollection : BaseCollection<Lottery>
    {
        #region Initializing Collection 01
        #endregion
    }

    public class WinningNumberCollection : BaseCollection<Lottery>
    {
        private int drawingId;
        private int lotteryId;

        public WinningNumberCollection(int lotteryId, int drawingId)
        {
            this.lotteryId = lotteryId;
            this.drawingId = drawingId;
        }
    }
}
