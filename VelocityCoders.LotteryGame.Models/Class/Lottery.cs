using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.LotteryGame.Models;

namespace VelocityCoders.LotteryGame.Models
{
    public class Lottery : BallType 
    { 
        public int LotteryId { get; set; }
        public string LotteryName { get; set; }
        public string LotteryNameAbbreviation { get; set; }
        public string HowToPlay { get; set; }
        public string DescriptionLottery { get; set; }
        public int SpecialBall { get; set; }
        public Drawing Drawing { get; set; }
        public Drawing DrawingDate { get; set; }
        public WinningNumber Number { get; set; }

        //public Lottery()
        //{
        //this.Drawing = new Drawing();
        //}
   }
}
