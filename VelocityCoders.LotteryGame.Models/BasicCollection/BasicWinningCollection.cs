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
    public class BasicWinningCollection : BaseCollection<BasicWinningNumber>
    {
        private int number;

        public BasicWinningCollection()
        {
        }

        public BasicWinningCollection(int number)
        {
            this.number = number;
        }

    }
}

