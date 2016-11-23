using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.BasicCollection;
using VelocityCoders.LotteryGame.DAL.BasicDAL;

namespace VelocityCoders.LotteryGame.BLL.BasicBLL
{
    public class BasicBallTypeBLL
    {
        #region GET ITEM

        public static BasicBallType GetItem(int ballTypeId)
        {
            return BasicBallTypeDAL.GetItem(ballTypeId);
        }
        #endregion

        #region GET COLLECTION 

        public static BasicBallTypeCollection GetCollection(BallTypeEnum description)
        {
            BasicBallTypeCollection collection = BasicBallTypeDAL.GetCollection(description);
            return collection;
        }

        #endregion

    }
}
