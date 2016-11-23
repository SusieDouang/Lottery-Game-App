using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryGame.Models.Enums
{
    public enum LotteryDrawingEnum
    {
        ///<summary>
        /// Defaults to none
        ///</summary>

        None = 0,

        GetDate = 1,

        GetItemOrderByDate = 2,

        GetLotteryGameNumbers = 3,

        GetCollection = 4,

        GetDrawing = 5,

        GetLotteryId = 6,

        GetItem = 7,

        GetItemNumber = 8
    }
}
