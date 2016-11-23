using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Susie.Common;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Collections;
using VelocityCoders.LotteryGame.BLL;
using VelocityCoders.LotteryGame.DAL;
using VelocityCoders.LotteryGame.Models.Enums;

namespace VelocityCoders.LotteryGame.BLL
{
    public static class BallTypeBLL
    {
        #region GET ITEM - BALLTYPE

        #endregion


        #region GET COLLECTION - BALL TYPE

        public static BallTypeCollection GetCollection(BallTypeEnum ballType)
        {
            BallTypeCollection ballTypeList = BallTypeDAL.GetCollection(ballType);

            return ballTypeList;
        }

        #endregion

    }
}
