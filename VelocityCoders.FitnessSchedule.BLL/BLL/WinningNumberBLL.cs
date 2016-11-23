using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.Collections;
using VelocityCoders.LotteryGame.DAL;
using Susie.Common;



namespace VelocityCoders.LotteryGame.BLL
{
    public static class WinningNumberBLL
    {
        #region GET ITEM WINNING NUMBER ID

        public static WinningNumber GetWinningNumber(int LotteryId)
        {
            return WinningNumberDAL.GetWinningNumber(LotteryId);
        }

        public static Lottery GetItem(int lotteryId)
        {
            return LotteryDAL.GetItem(lotteryId);
        }

        #endregion

        #region GET COLLECTION

        //public static WinningNumberCollection GetCollection()
        //{
        //    return WinningNumberDAL.GetCollection();
        //}

        public static WinningNumberCollection GetCollection(int lotteryId, int drawingId)
        {
            WinningNumberCollection collection = WinningNumberDAL.GetCollection(lotteryId, drawingId);
            return collection;
        }


        public static DrawingCollection GetCollection(LotteryDrawingEnum lotteryId)
        {
            DrawingCollection collection = DrawingDAL.GetCollection(lotteryId);
            return collection;
        }

        public static DrawingCollection GetCollection(int lotteryId)
        {
            return DrawingDAL.GetCollection(lotteryId);
        }

        public static WinningNumberCollection GetCollectionBallType(int LotteryId, int DrawingId)
        {
            return WinningNumberDAL.GetCollectionBallType(LotteryId, DrawingId);
        }
             

        #endregion

        #region INSERT, UPDATE

        public static int Save(WinningNumber winToSave)
        {
            int returnValue;
            returnValue = WinningNumberDAL.Save(winToSave);

            return returnValue;
        }

        #endregion
    }
}
