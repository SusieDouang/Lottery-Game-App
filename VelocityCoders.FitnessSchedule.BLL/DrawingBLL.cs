using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.Collections;
using VelocityCoders.LotteryGame.DAL;

namespace VelocityCoders.LotteryGame.BLL
{
    public static class DrawingBLL
    {
        #region

        #endregion


        #region GET ITEM DRAWING

        public static Drawing GetDrawing(int drawingId)
        {
            return DrawingDAL.GetDrawing(drawingId);
        }

        #endregion

        #region GET COLLECTION

        public static DrawingCollection GetCollection(LotteryDrawingEnum drawingLottery)
        {
            DrawingCollection collection = DrawingDAL.GetCollection(drawingLottery);
            return collection;
        }
        #endregion
    }
}