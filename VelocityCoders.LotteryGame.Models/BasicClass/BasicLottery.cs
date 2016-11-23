using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Susie.Common;

namespace VelocityCoders.LotteryGame.Models
{
    public class BasicLottery : Base
    {
        public int LotteryId { get; set; }
        public string LotteryName { get; set; }
        public int SpecialBall { get; set; }
        public string LotteryNameAbbreviation { get; set; }
        public string HowToPlay { get; set; }
        public string Description { get; set; }
    }
}
